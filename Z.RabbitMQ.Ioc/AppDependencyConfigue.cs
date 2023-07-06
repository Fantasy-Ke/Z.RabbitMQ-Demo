using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.RabbitMQ.Consumers.Domain.EventHandlers;
using Z.RabbitMQ.Consumers.Domain.Events;
using Z.RabbitMQ.Domain.Core.Bus;

namespace Z.RabbitMQ.Ioc
{
    public static class AppDependencyConfigue
    {

        public static void ConfigureEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBasicBus>();
            eventBus.Subscriber<NewPersonCreatedEvent, ConsumersNewPersonEventHandler>();
            eventBus.Subscriber<UpdatePersonEvent, ConsumersUpdatePersonEventHandler>();
            eventBus.Subscriber<DeletePersonEvent, ConsumersDeletePersonEventHandler>();
        }
    }
}
