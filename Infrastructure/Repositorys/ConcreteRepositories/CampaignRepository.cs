using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class CampaignRepository : Repository<Campaign>, ICampaignRepository
{
    public CampaignRepository(DbContext context) : base(context) { }

    public Task<IEnumerable<Campaign>> GetCampaignsForBusinessAsync(int businessId)
    {
        throw new NotImplementedException();
    }
}
