
namespace SkillBridge.Infrastructure.Repos;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<bool> SaveAsync(T entity)
    {
        if (entity is null) return await Task.FromResult(false);

        _context.Set<T>().Add(entity);
        return await Task.FromResult(true);
    }
    public async Task<bool> SaveRangeAsync(List<T> entities)
    {
        if (entities?.Count > 0)
        {
            _context.Set<T>().AddRange(entities);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        if (entity is null) return await Task.FromResult(false);

        _context.Entry(entity).State = EntityState.Modified;
        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateRangeAsync(List<T> entities)
    {
        if (entities?.Count > 0)
        {
            _context.Set<T>().UpdateRange(entities);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }

    public async Task<bool> ExistAsync(Expression<Func<T, bool>> match)
    {
        return await _context.Set<T>().AsNoTracking().AnyAsync(match);
    }

    public async Task<T?> GetItemAsync(Expression<Func<T, bool>> match)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(match);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return id > 0 ? await _context.Set<T>().FindAsync(id) : null;
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> match)
    {
        return await _context.Set<T>().AsNoTracking().Where(match).ToListAsync();
    }
    public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> match)
    {
        return _context.Set<T>().AsNoTracking().Where(match);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> match)
    {
        return await _context.Set<T>().AsNoTracking().CountAsync(match);
    }

    public void SoftDelete(T entity)
    {
        var prop = entity.GetType().GetProperty("IsDeleted");

        if (prop != null)
        {
            prop.SetValue(entity, true);
        }
    }
}