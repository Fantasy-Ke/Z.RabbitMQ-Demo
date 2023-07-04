﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System;
using Z.RabbitMQ.Domain.Core.Commands;
using Z.RabbitMQ.Domain.Core.Events;
using Newtonsoft.Json;
using Z.RabbitMQ.Domain.Core.Bus;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;

namespace Z.RabbitMQ.Bus
{
    public class ZRabbitMQBus : IEventBasicBus
    {

        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;
        private readonly IServiceProvider _serviceProvider;

        public ZRabbitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }

        public Task SendCommandsAsync<T>(T command) where T : EventCommandClass
        {
            return _mediator.Send(command);
        }

        public void PublishAsync<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventName = @event.GetType().Name;

                channel.QueueDeclare(eventName, false, false, false, null);

                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", eventName, null, body);
            }
        }

        public void Subscriber<T, THand>()
            where T : Event
            where THand : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(THand);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if (_handlers[eventName].Any(s => s.GetType() == handlerType))
            {
                throw new ArgumentException(
                    $"Handler Type {handlerType.Name} already registered for'{eventName}'",
                    nameof(handlerType));
            }

            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                DispatchConsumersAsync = true
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var eventName = typeof(T).Name;

            channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;

            channel.BasicConsume(eventName, true, consumer);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_handlers.ContainsKey(eventName))
            {

                var subscriptions = _handlers[eventName];
                foreach (var subscription in subscriptions)
                {
                    var handler = _serviceProvider.GetService(subscription);
                    //var handler = activator.createinstance(subscription);
                    if (handler == null) { continue; }
                    var eventtype = _eventTypes.FirstOrDefault(x => x.Name == eventName) ?? GetType();
                    var @event = JsonConvert.DeserializeObject(message, eventtype);
                    var conretetype = typeof(IEventHandler<>).MakeGenericType(eventtype);
                    await (Task)conretetype.GetMethod("HandleAsync").Invoke(handler, new object[] { @event });
                }
            }
        }

    }
}