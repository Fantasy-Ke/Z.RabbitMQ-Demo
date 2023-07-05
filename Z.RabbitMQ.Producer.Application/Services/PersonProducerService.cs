using Z.RabbitMQ.Producer.Application.Interfaces;
using Z.RabbitMQ.Producer.Domain.Interfaces;
using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Application.Services
{
    public class PersonProducerService : IPersonsProducerService
    {
        private readonly IPersonProducerRepository _personRepository;

        public PersonProducerService(IPersonProducerRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetConsumersPersons()
        {
            return await _personRepository.GetPersons();
        }
    }
}
