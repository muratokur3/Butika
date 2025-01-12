using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class BusinessCampaignRepository : Repository<BusinessCampaign>, IBusinessCampaignRepository
{
    public BusinessCampaignRepository(DbContext context) : base(context) { }
    public Task<List<BusinessCampaign>> GetByBusinessIdAsync(int businessId)
    {
        throw new NotImplementedException();
    }
}
