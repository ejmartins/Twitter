using System;
using System.Collections.Generic;
using System.Text;

namespace Ejmartins.Twitter.Domain.Shared.Validation
{
    public interface IGenericValidation<TEntity> : IValidation
    {
        Dictionary<string, IValidationRule<TEntity>> Rules { get; }
        ValidationResult Validate(TEntity entity);
        void ThrowIfInvalid(TEntity entity);
    }
}
