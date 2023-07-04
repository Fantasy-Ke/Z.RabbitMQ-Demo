using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.RabbitMQ.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime TimeNow { get; protected set; }

        public Event()
        {
            TimeNow = DateTime.Now;
        }
    }
}
