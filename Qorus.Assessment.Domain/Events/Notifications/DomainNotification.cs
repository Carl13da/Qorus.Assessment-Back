using System;

namespace Qorus.Assessment.Domain.Events.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public object Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, object value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
