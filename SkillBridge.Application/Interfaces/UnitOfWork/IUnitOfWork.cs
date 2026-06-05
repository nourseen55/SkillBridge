
using SkillBridge.Application.Interfaces.Repositories;

namespace SkillBridge.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;

        Task<int> CompleteAsync();
    }
}
