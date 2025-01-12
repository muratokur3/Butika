using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class BusinessMarketplaceRepository : Repository<BusinessMarketplace>, IBusinessMarketplaceRepository
{
    public BusinessMarketplaceRepository(DbContext context) : base(context) { }

    public Task<IEnumerable<Marketplace>> GetMarketplacesForBusinessAsync(int businessId)
    {
        throw new NotImplementedException();
    }
}
