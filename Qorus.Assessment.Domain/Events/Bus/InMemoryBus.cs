using MediatR;
using Qorus.Assessment.Domain.Commands;
using Qorus.Assessment.Domain.Events.Notifications;
using Qorus.Assessment.Domain.Interfaces.Events;
using Qorus.Assessment.Domain.Queries;
using System.Threading.Tasks;

namespace Qorus.Assessment.Domain.Events.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly DomainNotificationHandler _notificationHandler;

        public InMemoryBus(IMediator mediator, INotificationHandler<DomainNotification> notificationHandler)
        {
            _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
            _notificationHandler = (DomainNotificationHandler)notificationHandler ?? throw new System.ArgumentNullException(nameof(notificationHandler));
        }

        public void ClearNotifications()
        {
            _notificationHandler.Clear();
        }

        public INotificationHandler<DomainNotification> GetNotificationHandler()
        {
            return _notificationHandler;
        }

        public bool HasNotification()
        {
            return _notificationHandler.HasNotifications();
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task<TResponse> SendQuery<TResponse>(Query<TResponse> query) where TResponse : class
        {
            return _mediator.Send(query);
        }
    }
}
