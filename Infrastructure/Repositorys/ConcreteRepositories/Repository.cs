using Infrastructure.Context;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;
public class Repository<T> : IRepository<T>
       where T : class
{
    protected readonly AppDbContext context;
    //private readonly DbSet<T> context;
    public Repository(AppDbContext ctx)
    {
        context = ctx;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }


    public async Task<T> GetByIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<bool> AddAsync(T entity)
    {
        await context.AddAsync(entity);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        context.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }

    public Task<bool> DeleteAsync(T entity)
    {
        var result = context.Remove(entity);
        return Task.FromResult(result.State == EntityState.Deleted);

    }
}
