using Z.RabbitMQ.Consumers.Domain.Models;

namespace MicroRabbitMQ.Transfer.Application.Interfaces
{
    public interface IEmployeeTransferService
    {
        Task<IEnumerable<Person>> GetConsumersPerson();
    }
}
