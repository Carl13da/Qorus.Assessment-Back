using MediatR;
using System.Threading.Tasks;
using Qorus.Assessment.Domain.Commands;
using Qorus.Assessment.Domain.Events;
using Qorus.Assessment.Domain.Events.Notifications;
using Qorus.Assessment.Domain.Queries;

namespace Qorus.Assessment.Domain.Interfaces.Events
{
    public interface IMediatorHandler
    {
        void ClearNotifications();
        bool HasNotification();
        Task RaiseEvent<T>(T @event) where T : Event;
        Task<TResponse> SendQuery<TResponse>(Query<TResponse> query) where TResponse : class;
        Task SendCommand<T>(T command) where T : Command;
        INotificationHandler<DomainNotification> GetNotificationHandler();
    }
}
