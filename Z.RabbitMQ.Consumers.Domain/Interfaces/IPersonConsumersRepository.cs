using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Domain.Interfaces
{
    public interface IPersonConsumersRepository
    {
        Task<IEnumerable<Person>> GetConsumersPersons();
        Task ConsumersInsertPerson(Person employee);
        Task ConsumersUpdatePerson(int Id, Person employee);
        Task ConsumersDeletePerson(int id);
    }
}
