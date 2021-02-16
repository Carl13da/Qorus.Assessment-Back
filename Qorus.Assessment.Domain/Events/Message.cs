using MediatR;
using Qorus.Assessment.Domain.Interfaces.Events;
using System;

namespace Qorus.Assessment.Domain.Events
{
    public abstract class Message : IRequest, IRequestBase
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
    }
}
