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

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { set; get; }

        public int Skip { set; get; }

        public bool IsPagingEnabled { set; get; }

        protected void AddInclude(Expression<Func<T, object>> expression)
        {
            Includes.Add(expression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

    }


}
