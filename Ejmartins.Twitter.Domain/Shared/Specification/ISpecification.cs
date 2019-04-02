using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ejmartins.Twitter.Domain.Shared.Specification
{
    public interface ISpecification<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> Predicate { get; }
        bool IsSatisfiedBy(TEntity entity);
    }
}
