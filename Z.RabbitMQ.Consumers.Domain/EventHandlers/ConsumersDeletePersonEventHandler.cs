using Z.RabbitMQ.Domain.Core.Bus;
using Z.RabbitMQ.Consumers.Domain.Events;
using Z.RabbitMQ.Consumers.Domain.Interfaces;

namespace Z.RabbitMQ.Consumers.Domain.EventHandlers
{
    public class ConsumersDeletePersonEventHandler : IEventHandler<DeletePersonEvent>
    {
        private readonly IPersonConsumersRepository _personProducerRepository;
        public ConsumersDeletePersonEventHandler(IPersonConsumersRepository personProducerRepository)
        {
            _personProducerRepository = personProducerRepository;
        }

        public async Task HandleAsync(DeletePersonEvent @event)
        {
            await _personProducerRepository.ConsumersDeletePerson(@event.Id);
        }
    }
}
