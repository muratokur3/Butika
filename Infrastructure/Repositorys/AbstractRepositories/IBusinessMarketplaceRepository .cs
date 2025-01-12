using Domain.Entities;

namespace Infrastructure.Repositorys.AbstractRepositories;

public interface IBusinessMarketplaceRepository : IRepository<BusinessMarketplace>
{
    Task<IEnumerable<Marketplace>> GetMarketplacesForBusinessAsync(int businessId);
    Task<IEnumerable<Business>> GetBusinessesForMarketplaceAsync(int marketplaceId);

}
