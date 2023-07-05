using Z.RabbitMQ.Domain.Core.Bus;
using Z.RabbitMQ.Consumers.Domain.Events;
using Z.RabbitMQ.Consumers.Domain.Interfaces;
using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Domain.EventHandlers
{
    public class ConsumersUpdatePersonEventHandler : IEventHandler<UpdatePersonEvent>
    {
        private readonly IPersonConsumersRepository _personProducerRepository;
        public ConsumersUpdatePersonEventHandler(IPersonConsumersRepository personProducerRepository)
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
