using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ejmartins.Twitter.Domain.Shared.Validation;

namespace Ejmartins.Twitter.Domain.Shared.Exception
{
    public class ValidationException : DomainException
    {
        public IReadOnlyCollection<ValidationError> Errors { get; private set; }

        public ValidationException(IEnumerable<ValidationError> errors)
            : base(string.Join(Environment.NewLine, errors.Select(x => x.Message).ToArray()))
        {
            Errors = new List<ValidationError>(errors);
        }

        public ValidationException(ValidationError error)
            : base(error.Message)
        {
            Errors = new List<ValidationError> { error };
        }

        public override string Message => string.Join(Environment.NewLine, Errors.Select(x => x.Message).ToArray());
    }
}
