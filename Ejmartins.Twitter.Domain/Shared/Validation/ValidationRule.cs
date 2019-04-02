using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Domain.Shared.Specification;

namespace Ejmartins.Twitter.Domain.Shared.Validation
{
    public class ValidationRule<TEntity> : IValidationRule<TEntity> where TEntity : class
    {
        private readonly ISpecification<TEntity> _specificationRule;
        public string ErrorMessage { get; set; }
        public ValidationRule(ISpecification<TEntity> specificationRule, string errorMessage)
        {
            _specificationRule = specificationRule;
            ErrorMessage = errorMessage;
        }
        public bool Valid(TEntity entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }
    }
}
