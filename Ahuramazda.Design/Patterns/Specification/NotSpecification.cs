using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ahuramazda.Design.Patterns
{
    internal sealed class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> LeftExpression;
        public NotSpecification(Specification<T> leftExpression)
        {
            LeftExpression = leftExpression;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftexpr = LeftExpression.ToExpression();

            var expr = Expression.Not(leftexpr.Body);

            return Expression.Lambda<Func<T, bool>>(expr, leftexpr.Parameters.Single());
        }
    }
}
