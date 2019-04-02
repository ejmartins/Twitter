using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Domain.Shared.Exception;
using Ejmartins.Twitter.Domain.Shared.Specification;
using Ejmartins.Twitter.Domain.Shared.Exception;

namespace Ejmartins.Twitter.Domain.Shared.Validation
{
    public class Validation<TEntity> : IGenericValidation<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IValidationRule<TEntity>> _validationsRules;
        public Dictionary<string, IValidationRule<TEntity>> Rules { get { return _validationsRules; } }

        public Validation()
        {
            _validationsRules = new Dictionary<string, IValidationRule<TEntity>>();
        }

        public virtual void AddRule(IValidationRule<TEntity> validationRule)
        {
            var ruleName = validationRule.GetType() + Guid.NewGuid().ToString("D");
            _validationsRules.Add(ruleName, validationRule);
        }

        public virtual void AddRule(ISpecification<TEntity> specification, string errorMessage)
        {
            AddRule(new ValidationRule<TEntity>(specification, errorMessage));
        }

        public virtual void RemoveRule(string ruleName)
        {
            _validationsRules.Remove(ruleName);
        }

        public virtual ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();
            foreach (var key in _validationsRules.Keys)
            {
                var rule = _validationsRules[key];
                if (!rule.Valid(entity))
                {
                    result.Add(new ValidationError(rule.ErrorMessage));
                }
            }
            return result;
        }

        public void ThrowIfInvalid(TEntity entity)
        {
            var validationResult = Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
