using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkillBridge.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> SaveAsync(T entity);
        Task<bool> SaveRangeAsync(List<T> entities);
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateRangeAsync(List<T> entities);
        Task<bool> ExistAsync(Expression<Func<T, bool>> match);
        Task<T?> GetItemAsync(Expression<Func<T, bool>> match);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> match);
        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> match);
        Task<int> CountAsync(Expression<Func<T, bool>> match);
        void SoftDelete(T entity);
    }
}
