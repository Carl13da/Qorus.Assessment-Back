using FluentValidation.Results;
using Qorus.Assessment.Domain.Events;
using System;

namespace Qorus.Assessment.Domain.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
