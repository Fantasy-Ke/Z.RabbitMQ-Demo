using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Application.Interfaces
{
    public interface IPersonsConsumersService
    {
        Task<IEnumerable<Person>> GetConsumersPersons();
    }
}
