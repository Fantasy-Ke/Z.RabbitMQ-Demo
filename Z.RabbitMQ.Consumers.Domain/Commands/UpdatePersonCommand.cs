

namespace Z.RabbitMQ.Consumers.Domain.Commands
{
    public class UpdatePersonCommand : PersonCommand
    {
        public UpdatePersonCommand(int id, string firstName, string lastName, int age, int salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
    }
}
