using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Domain.Interfaces
{
    public interface IPersonConsumersRepository
    {
        Task<IEnumerable<Person>> GetProducerEmployees();
        Task ProducerInsertPerson(Person employee);
        Task ProducerUpdatePerson(int Id, Person employee);
        Task ProducerDeletePerson(int id);
    }
}
