using System;
using System.Collections.Generic;
using System.Text;

namespace Ejmartins.Twitter.Domain.Shared.Validation
{
    public interface IValidationRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Valid(TEntity entity);
    }
}
