using MediatR;
using Qorus.Assessment.Domain.Interfaces.Events;
using System;

namespace Qorus.Assessment.Domain.Queries
{
    public class QueryMessage<TResponse> : IRequest<TResponse>, IBaseRequest, IRequestBase
    {
        protected QueryMessage()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
    }
}
