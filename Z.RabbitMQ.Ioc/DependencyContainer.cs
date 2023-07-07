using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Z.RabbitMQ.Bus;
using Z.RabbitMQ.Bus.Options;
using Z.RabbitMQ.Consumers.Application.Interfaces;
using Z.RabbitMQ.Consumers.Application.Services;
using Z.RabbitMQ.Consumers.Data;
using Z.RabbitMQ.Consumers.Data.Repository;
using Z.RabbitMQ.Consumers.Domain.EventHandlers;
using Z.RabbitMQ.Consumers.Domain.Events;
using Z.RabbitMQ.Consumers.Domain.Interfaces;
using Z.RabbitMQ.Domain.Core.Bus;
using Z.RabbitMQ.Producer.Application.Interfaces;
using Z.RabbitMQ.Producer.Application.Services;
using Z.RabbitMQ.Producer.Data;
using Z.RabbitMQ.Producer.Data.Repository;
using Z.RabbitMQ.Producer.Domain.CommandHandlers;
using Z.RabbitMQ.Producer.Domain.Commands;
using Z.RabbitMQ.Producer.Domain.Interfaces;

namespace Z.RabbitMQ.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, RabbitMQOptions rabbitMQOptions)
        {
            //Domain Bus

            services.AddSingleton<IEventBasicBus, ZRabbitMQBus>(sp =>
            {
                var scopFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new ZRabbitMQBus(sp.GetService<IMediator>(), services.BuildServiceProvider(), rabbitMQOptions);
            });


            //Subscriptions
            services.AddTransient<ConsumersNewPersonEventHandler>();
            services.AddTransient<ConsumersUpdatePersonEventHandler>();
            services.AddTransient<ConsumersDeletePersonEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<NewPersonCreatedEvent>, ConsumersNewPersonEventHandler>();
            services.AddTransient<IEventHandler<UpdatePersonEvent>, ConsumersUpdatePersonEventHandler>();
            services.AddTransient<IEventHandler<DeletePersonEvent>, ConsumersDeletePersonEventHandler>();

            //Domain Person Command
            services.AddTransient<IRequestHandler<CreateNewPersonCommand, bool>, NewPersonCommandHandler>();
            services.AddTransient<IRequestHandler<UpdatePersonCommand, bool>, UpdatePersonCommandHandler>();
            services.AddTransient<IRequestHandler<DeletePersonCommand, bool>, DeletePersonCommandHandler>();

            // Application Services            
            services.AddTransient<IPersonsProducerService, PersonProducerService>();
            services.AddTransient<IPersonConsumersService, PersonConsumersService>();

            //Data
            services.AddTransient<IPersonProducerRepository, PersonProducerRepository>();
            services.AddTransient<IPersonConsumersRepository, PersonConsumersRepository>();

            services.AddTransient<ProducerDbContext>();
            services.AddTransient<ConsumersDbContext>();
        }
    }
}