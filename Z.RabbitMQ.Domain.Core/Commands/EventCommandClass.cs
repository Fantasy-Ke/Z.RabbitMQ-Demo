using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.RabbitMQ.Domain.Core.Commands
{
    public abstract class EventCommandClass : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        public DateTime TimeNow { get; protected set; }
        protected EventCommandClass()
        {

            MessageType = GetType().Name;
            TimeNow = DateTime.Now;
        }
    }
}
