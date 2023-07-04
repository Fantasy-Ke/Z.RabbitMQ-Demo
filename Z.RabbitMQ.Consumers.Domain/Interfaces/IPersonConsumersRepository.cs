using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Domain.Interfaces
{
    public interface IPersonConsumersRepository
    {
        Task<IEnumerable<Person>> GetPersons();
        Person GetPersonById(int Id);
    }
}
