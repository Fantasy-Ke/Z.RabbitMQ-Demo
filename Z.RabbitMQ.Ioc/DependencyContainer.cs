using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Z.RabbitMQ.Bus;
using Z.RabbitMQ.Domain.Core.Bus;
using Z.RabbitMQ.Producer.Application.Interfaces;
using Z.RabbitMQ.Producer.Application.Services;
using Z.RabbitMQ.Producer.Data;
using Z.RabbitMQ.Producer.Data.Repository;
using Z.RabbitMQ.Producer.Domain.Interfaces;

namespace Z.RabbitMQ.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBasicBus, ZRabbitMQBus>(sp =>
            {
                var scopFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new ZRabbitMQBus(sp.GetService<IMediator>(), services.BuildServiceProvider());
            });

            // Application Services            
            services.AddTransient<IPersonsProducerService, PersonProducerService>();

            //Data
            services.AddTransient<IPersonProducerRepository, PersonProducerRepository>();

            services.AddTransient<ProducerDbContext>();
        }
    }
}