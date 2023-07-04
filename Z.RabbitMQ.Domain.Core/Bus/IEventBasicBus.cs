using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.RabbitMQ.Domain.Core.Commands;
using Z.RabbitMQ.Domain.Core.Events;

namespace Z.RabbitMQ.Domain.Core.Bus
{
    public interface IEventBasicBus
    {
        Task SendCommandsAsync<T>(T commands) where T : EventCommandClass;

        void PublishAsync<T>(T commands) where T : Event;


        void Subscriber<T, THand>()
            where T : Event
            where THand : IEventHandler<T>;
    }
} 
