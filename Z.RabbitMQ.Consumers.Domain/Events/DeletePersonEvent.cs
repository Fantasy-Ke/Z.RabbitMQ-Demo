using Z.RabbitMQ.Domain.Core.Events;

namespace Z.RabbitMQ.Consumers.Domain.Events
{
    public class DeletePersonEvent : Event
    {
        public int Id { get; private set; }

        public DeletePersonEvent(int id)
        {
            Id = id;
        }
    }
}
