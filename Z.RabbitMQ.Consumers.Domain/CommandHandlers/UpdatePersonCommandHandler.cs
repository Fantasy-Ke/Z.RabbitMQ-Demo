using MediatR;
using Z.RabbitMQ.Consumers.Domain.Commands;
using Z.RabbitMQ.Consumers.Domain.Events;
using Z.RabbitMQ.Domain.Core.Bus;

namespace Z.RabbitMQ.Consumers.Domain.CommandHandlers
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IEventBasicBus _basicBus;

        public UpdatePersonCommandHandler(IEventBasicBus basicBus)
        {
            _basicBus = basicBus;
        }
        public Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            //Publish event to RabbitMQ
            _basicBus.PublishAsync(new UpdatePersonEvent(request.Id, request.FirstName, request.LastName, request.Age, request.Salary));

            return Task.FromResult(true);
        }
    }
}
