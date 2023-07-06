using Z.RabbitMQ.Domain.Core.Bus;
using Z.RabbitMQ.Consumers.Domain.Events;
using Z.RabbitMQ.Consumers.Domain.Interfaces;
using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Domain.EventHandlers
{
    public class ConsumersNewPersonEventHandler : IEventHandler<NewPersonCreatedEvent>
    {
        private readonly IPersonConsumersRepository _personProducerRepository;
        public ConsumersNewPersonEventHandler(IPersonConsumersRepository personProducerRepository)
        {
            _personProducerRepository = personProducerRepository;
        }
        public async Task HandleAsync(NewPersonCreatedEvent @event)
        {
            await _personProducerRepository.ConsumersInsertPerson(new Person()
            {
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                Age = @event.Age,
                Salary = @event.Salary,
            });
        }
    }
}
