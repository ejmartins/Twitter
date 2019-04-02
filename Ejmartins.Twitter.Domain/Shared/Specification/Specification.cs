using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ejmartins.Twitter.Domain.Shared.Specification
{
    public abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        public abstract Expression<Func<TEntity, bool>> Predicate { get; }

        private Func<TEntity, bool> _compiledPredicate;

        public Func<TEntity, bool> ColpiledPredicate
        {
            get { return _compiledPredicate ?? (_compiledPredicate = Predicate.Compile()); }
        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            return ColpiledPredicate(entity);
        }
    }
}
