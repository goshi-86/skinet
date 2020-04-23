using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T>

    {
        public BaseSpecifications()
        {
        }

        public BaseSpecifications(Expression<Func<T, bool>> criteria )
        {
            Criteria = criteria;
           
        }

        public System.Linq.Expressions.Expression<Func<T, bool>> Criteria { get; }

        public List<System.Linq.Expressions.Expression<Func<T, object>>> Includes 
        { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> expression)
        {
            Includes.Add(expression);
        }
    }


}
