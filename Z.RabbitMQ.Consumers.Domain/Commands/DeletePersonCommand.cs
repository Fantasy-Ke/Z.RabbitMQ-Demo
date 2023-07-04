namespace Z.RabbitMQ.Consumers.Domain.Commands
{
    public class DeletePersonCommand : DeleteCommand
    {
        public DeletePersonCommand(int id)
        {
            Id = id;
        }
    }
}
