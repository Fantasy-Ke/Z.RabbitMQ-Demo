using Z.RabbitMQ.Domain.Core.Events;

namespace Z.RabbitMQ.Producer.Domain.Events
{
    public class NewPersonCreatedEvent : Event
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public int Salary { get; private set; }

        public NewPersonCreatedEvent(string firstName, string lastName, int age, int salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
    }
}
