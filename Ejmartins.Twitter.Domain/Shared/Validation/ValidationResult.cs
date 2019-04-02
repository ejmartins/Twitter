using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejmartins.Twitter.Domain.Shared.Validation
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors;
        public bool IsValid { get { return !_errors.Any(); } }
        public IEnumerable<ValidationError> Errors { get { return _errors; } }

        public ValidationResult()
        {
            _errors = new List<ValidationError>();
        }

        public ValidationResult Add(string errorMessage)
        {
            _errors.Add(new ValidationError(errorMessage));
            return this;
        }

        public ValidationResult Add(ValidationError error)
        {
            _errors.Add(error);

            return this;
        }

        public ValidationResult Add(params ValidationResult[] validationResults)
        {
            if (validationResults == null)
            {
                return this;
            }

            validationResults
                .Where(_ => _ != null)
                .ToList()
                .ForEach(_ => _errors.AddRange(_.Errors));

            return this;
        }

        public ValidationResult Remove(ValidationError error)
        {
            if (_errors.Contains(error))
            {
                _errors.Remove(error);
            }

            return this;
        }
    }
}
