using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ahuramazda.Design.Patterns
{
    internal sealed class NullSpecification<T> : Specification<T>
    {

        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}
