
using SkillBridge.Application.Interfaces.Repositories;

namespace SkillBridge.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<TResult> ExecuteInTransactionAsync<TResult>(Func<Task<TResult>> action);
        Task<bool> ExecuteInTransactionAllContextAsync(Func<Task<bool>> action);
        Task<int> CompleteAsync();
    }
}
