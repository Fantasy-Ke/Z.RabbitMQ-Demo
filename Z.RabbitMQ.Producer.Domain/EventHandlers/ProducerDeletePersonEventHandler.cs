using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Transfer.Domain.Events;
using MicroRabbitMQ.Transfer.Domain.Interfaces;
using MicroRabbitMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Z.RabbitMQ.Domain.Core.Bus;
using Z.RabbitMQ.Domain.Core.Events;
using Z.RabbitMQ.Producer.Domain.Events;
using Z.RabbitMQ.Producer.Domain.Interfaces;

namespace Z.RabbitMQ.Producer.Domain.EventHandlers
{
    public class ProducerDeletePersonEventHandler : IEventHandler<DeletePersonEvent>
    {
        private readonly IPersonProducerRepository _personProducerRepository;
        public ProducerDeletePersonEventHandler(IPersonProducerRepository personProducerRepository)
        {
            _personProducerRepository = personProducerRepository;
        }

        public async Task HandleAsync(DeletePersonEvent @event)
        {
            await _personProducerRepository.ProducerDeletePerson(@event.Id);
        }
    }
}
