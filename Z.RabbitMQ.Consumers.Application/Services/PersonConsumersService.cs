using Z.RabbitMQ.Consumers.Application.Interfaces;
using Z.RabbitMQ.Consumers.Domain.Interfaces;
using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Application.Services
{
    public class PersonConsumersService : IPersonsConsumersService
    {
        private readonly IPersonConsumersRepository _personRepository;

        public PersonConsumersService(IPersonConsumersRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetConsumersPersons()
        {
            return await _personRepository.GetPersons();
        }
    }
}
