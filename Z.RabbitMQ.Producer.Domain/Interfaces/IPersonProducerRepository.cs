using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Domain.Interfaces
{
    public interface IPersonProducerRepository
    {
        Task<IEnumerable<Person>> GetProducerEmployees();
        Task ProducerInsertPerson(Person employee);
        Task ProducerUpdatePerson(int Id, Person employee);
        Task ProducerDeletePerson(int id);
    }
}
