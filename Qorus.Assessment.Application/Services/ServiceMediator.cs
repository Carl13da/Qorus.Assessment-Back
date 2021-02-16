using Qorus.Assessment.Domain.Events.Notifications;
using Qorus.Assessment.Domain.Interfaces.Events;

namespace Qorus.Assessment.Application.Services
{
    public abstract class ServiceMediator
    {
        protected IMediatorHandler Mediator { get; }

        protected ServiceMediator(IMediatorHandler mediator)
        {
            Mediator = mediator;
        }

        protected void NotifyError(string code, string message)
        {
            Mediator.RaiseEvent(new DomainNotification(code, message));
        }
        protected void NotifyError(string message) => NotifyError(message);
        protected bool HasNotification() => Mediator.HasNotification();
    }
}
