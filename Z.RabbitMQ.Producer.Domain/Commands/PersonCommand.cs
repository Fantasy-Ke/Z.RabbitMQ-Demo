using Z.RabbitMQ.Domain.Core.Commands;

namespace Z.RabbitMQ.Producer.Domain.Commands
{
    public class PersonCommand : EventCommandClass
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int Age { get; protected set; }
        public int Salary { get; protected set; }
    }
}
