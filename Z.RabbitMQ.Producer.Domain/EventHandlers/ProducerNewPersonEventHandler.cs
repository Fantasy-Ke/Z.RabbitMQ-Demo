using Z.RabbitMQ.Domain.Core.Bus;
using Z.RabbitMQ.Producer.Domain.Events;
using Z.RabbitMQ.Producer.Domain.Interfaces;
using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Domain.EventHandlers
{
    public class ProducerNewPersonEventHandler : IEventHandler<NewPersonCreatedEvent>
    {
        private readonly IPersonProducerRepository _personProducerRepository;
        public ProducerNewPersonEventHandler(IPersonProducerRepository personProducerRepository)
        {
            _personProducerRepository = personProducerRepository;
        }
        public async Task HandleAsync(NewPersonCreatedEvent @event)
        {
            await _personProducerRepository.ProducerInsertPerson(new Person()
            {
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                Age = @event.Age,
                Salary = @event.Salary,
            });
        }
    }
}
