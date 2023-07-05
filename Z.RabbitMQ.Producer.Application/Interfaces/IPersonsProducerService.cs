using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Application.Interfaces
{
    public interface IPersonsProducerService
    {
        Task<IEnumerable<Person>> GetConsumersPersons();
    }
}
