using Z.RabbitMQ.Domain.Core.Events;

namespace Z.RabbitMQ.Producer.Domain.Events
{
    public class UpdatePersonEvent : Event
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public int Salary { get; private set; }

        public UpdatePersonEvent(int id, string firstName, string lastName, int age, int salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
    }
}
