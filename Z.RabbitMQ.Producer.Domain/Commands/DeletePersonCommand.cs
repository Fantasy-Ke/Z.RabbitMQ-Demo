namespace Z.RabbitMQ.Producer.Domain.Commands
{
    public class DeletePersonCommand : DeleteCommand
    {
        public DeletePersonCommand(int id)
        {
            Id = id;
        }
    }
}
