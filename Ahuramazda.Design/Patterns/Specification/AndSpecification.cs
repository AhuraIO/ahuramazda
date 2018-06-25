﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ahuramazda.Design.Patterns
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> LeftExpression;
        private readonly Specification<T> RightExpression;
        public AndSpecification(Specification<T> leftExpression, Specification<T> rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftexpr = LeftExpression.ToExpression();
            var rightexpr = RightExpression.ToExpression();

            var expr = Expression.AndAlso(leftexpr.Body, rightexpr.Body);

            return Expression.Lambda<Func<T, bool>>(expr, leftexpr.Parameters.Single());
        }
    }
}
