using Z.RabbitMQ.Consumers.Application.Interfaces;
using Z.RabbitMQ.Consumers.Domain.Interfaces;
using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Application.Services
{
    public class PersonConsumersService : IPersonConsumersService
    {
        private readonly IPersonConsumersRepository _personConsumersRepository;

        public PersonConsumersService(IPersonConsumersRepository personConsumersRepository)
        {
            _personConsumersRepository = personConsumersRepository;
        }

        public async Task<IEnumerable<Person>> GetConsumersPerson()
        {
            return await _personConsumersRepository.GetConsumersPersons();
        }
    }
}
