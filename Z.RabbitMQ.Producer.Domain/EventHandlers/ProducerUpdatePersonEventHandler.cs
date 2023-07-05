using Z.RabbitMQ.Domain.Core.Bus;
using Z.RabbitMQ.Producer.Domain.Events;
using Z.RabbitMQ.Producer.Domain.Interfaces;
using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Domain.EventHandlers
{
    public class ProducerUpdatePersonEventHandler : IEventHandler<UpdatePersonEvent>
    {
        private readonly IPersonProducerRepository _personProducerRepository;
        public ProducerUpdatePersonEventHandler(IPersonProducerRepository personProducerRepository)
        {
            _personProducerRepository = personProducerRepository;
        }
        public async Task HandleAsync(UpdatePersonEvent @event)
        {
            await _personProducerRepository.ProducerUpdatePerson(@event.Id, new Person()
            {
                Id = @event.Id,
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                Age = @event.Age,
                Salary = @event.Salary,
            });
        }
    }
}
