using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Application.Interfaces
{
    public interface IPersonConsumersService
    {
        Task<IEnumerable<Person>> GetConsumersPerson();
    }
}
