using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Domain.Interfaces
{
    public interface IPersonProducerRepository
    {
        Task<IEnumerable<Person>> GetPersons();
        Task<Person> GetPersonById(int Id);
    }
}
