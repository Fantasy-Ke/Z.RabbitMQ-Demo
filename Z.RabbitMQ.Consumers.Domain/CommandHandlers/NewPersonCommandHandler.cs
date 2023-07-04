using MediatR;
using Z.RabbitMQ.Consumers.Domain.Commands;
using Z.RabbitMQ.Consumers.Domain.Events;
using Z.RabbitMQ.Domain.Core.Bus;

namespace Z.RabbitMQ.Consumers.Domain.CommandHandlers
{
    public class NewPersonCommandHandler : IRequestHandler<CreateNewPersonCommand, bool>
    {
        private readonly IEventBasicBus _basicBus;

        public NewPersonCommandHandler(IEventBasicBus basicBus)
        {
            _basicBus = basicBus;
        }
        public Task<bool> Handle(CreateNewPersonCommand request, CancellationToken cancellationToken)
        {
            //Publish event to RabbitMQ
            _basicBus.PublishAsync(new NewPersonCreatedEvent(request.FirstName, request.LastName, request.Age, request.Salary));

            return Task.FromResult(true);
        }
    }
}
