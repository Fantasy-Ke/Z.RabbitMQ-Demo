using MediatR;
using Z.RabbitMQ.Producer.Domain.Commands;
using Z.RabbitMQ.Producer.Domain.Events;
using Z.RabbitMQ.Domain.Core.Bus;

namespace Z.RabbitMQ.Producer.Domain.CommandHandlers
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IEventBasicBus _basicBus;

        public DeletePersonCommandHandler(IEventBasicBus basicBus)
        {
            _basicBus = basicBus;
        }
        public Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            //Publish event to RabbitMQ
            _basicBus.PublishAsync(new DeletePersonEvent(request.Id));

            return Task.FromResult(true);
        }
    }
}
