using Z.RabbitMQ.Domain.Core.Commands;

namespace Z.RabbitMQ.Consumers.Domain.Commands
{
    public class DeleteCommand : EventCommandClass
    {
        public int Id { get; protected set; }
    }
}
