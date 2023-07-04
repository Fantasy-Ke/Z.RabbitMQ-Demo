using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.RabbitMQ.Domain.Core.Events;

namespace Z.RabbitMQ.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> where TEvent : Event
    {
        Task HandleAsync(TEvent @event);
    }

}
