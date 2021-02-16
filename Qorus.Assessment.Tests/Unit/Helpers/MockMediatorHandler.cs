using MediatR;
using Qorus.Assessment.Domain.Commands;
using Qorus.Assessment.Domain.Events;
using Qorus.Assessment.Domain.Events.Notifications;
using Qorus.Assessment.Domain.Interfaces.Events;
using Qorus.Assessment.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qorus.Assessment.Tests.Unit.Helpers
{
    public class MockMediatorHandler : IMediatorHandler
    {
        private DomainNotificationHandler _domainNotification;
        private List<object> _commandQueryList = new List<object>();

        public MockMediatorHandler()
        {
            _domainNotification = new DomainNotificationHandler();
        }

        public void ClearNotifications() => _domainNotification.Clear();

        public INotificationHandler<DomainNotification> GetNotificationHandler() => _domainNotification;

        public bool HasNotification() => _domainNotification.HasNotifications();

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            _domainNotification.GetNotifications().Add(@event as DomainNotification);
            return Task.CompletedTask;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            _commandQueryList.Add(command);
            return Task.CompletedTask;
        }

        public Task<TResponse> SendQuery<TResponse>(Query<TResponse> query) where TResponse : class
        {
            _commandQueryList.Add(query);
            return Task.FromResult<TResponse>(null);
        }

        public bool HasNotificationWithType<TResponse>() where TResponse : class => _commandQueryList.Any(t => typeof(TResponse) == t.GetType());
    }
}
