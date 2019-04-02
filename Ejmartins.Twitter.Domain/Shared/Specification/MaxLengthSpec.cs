using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ejmartins.Twitter.Domain.Shared.Specification
{
    public class MaxLengthSpec<TEntity> : Specification<TEntity> where TEntity : class
    {
        private readonly int _maxLength;
        private readonly Func<TEntity, string> _propertyResolver;

        public MaxLengthSpec(Func<TEntity, string> property, int maxLength)
        {
            _maxLength = maxLength;
            _propertyResolver = property;
        }

        public override Expression<Func<TEntity, bool>> Predicate
        {
            get
            {
                return _ => _propertyResolver(_) == null || _propertyResolver(_).Length <= _maxLength;
            }
        }
    }
}
