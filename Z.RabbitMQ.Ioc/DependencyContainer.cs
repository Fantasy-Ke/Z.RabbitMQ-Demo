using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Z.RabbitMQ.Bus;
using Z.RabbitMQ.Consumers.Application.Interfaces;
using Z.RabbitMQ.Consumers.Application.Services;
using Z.RabbitMQ.Consumers.Data;
using Z.RabbitMQ.Consumers.Data.Repository;
using Z.RabbitMQ.Consumers.Domain.Interfaces;
using Z.RabbitMQ.Domain.Core.Bus;

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
            services.AddTransient<IPersonsConsumersService, PersonConsumersService>();

            //Data
            services.AddTransient<IPersonConsumersRepository, PersonConsumersRepository>();

            services.AddTransient<ConsumersDbContext>();
        }
    }
}