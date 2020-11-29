using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity

    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task<T> GetEntityWithSpec1(List<Expression<Func<T, object>>> includes, Expression<Func<T, bool>> criteria);

        Task<int> CountAsync(ISpecification<T> spec);


    }    
}
