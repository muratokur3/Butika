using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;
public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(DbContext context) : base(context) { }

    public Task<List<Category>> GetByBusinessIdAsync(int businessId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetCategoriesForBusinessAsync(int businessId)
    {
        throw new NotImplementedException();
    }
}