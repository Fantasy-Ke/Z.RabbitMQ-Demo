using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Application.Interfaces
{
    public interface IPersonsProducerService
    {
        Task<IEnumerable<Person>> GetConsumersPersons();
        Task<Person> GetPersonById(int Id);
        Task InsertPerson(Person employee);
        Task UpdatePerson(int Id, Person employee);
        Task DeletePerson(int id);
    }
}
