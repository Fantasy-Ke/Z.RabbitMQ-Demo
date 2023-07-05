using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Domain.Interfaces
{
    public interface IPersonProducerRepository
    {
        Task<IEnumerable<Person>> GetPersons();
        Person GetPersonById(int Id);
    }
}
