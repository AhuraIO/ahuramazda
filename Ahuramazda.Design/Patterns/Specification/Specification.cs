using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ahuramazda.Design.Patterns
{
    public abstract class Specification<T>
    {
        public static readonly Specification<T> All = new NullSpecification<T>();
        public bool IsStatisfyBy(T entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }

        public abstract Expression<Func<T, bool>> ToExpression();

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public Specification<T> Not(Specification<T> specification)
        {
            return new NotSpecification<T>(this);
        }
    }
}
