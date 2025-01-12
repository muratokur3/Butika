
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class BusinessTagRepository : Repository<BusinessTag>, IBusinessTagRepository
{
    public BusinessTagRepository(DbContext context) : base(context) { }

    public Task<IEnumerable<Tag>> GetTagsForBusinessAsync(int businessId)
    {
        throw new NotImplementedException();
    }
}
