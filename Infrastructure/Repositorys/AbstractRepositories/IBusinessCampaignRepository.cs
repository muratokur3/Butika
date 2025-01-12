

using Domain.Entities;

namespace Infrastructure.Repositorys.AbstractRepositories;

public interface IBusinessCampaignRepository: IRepository<BusinessCampaign>
{
    Task<List<BusinessCampaign>> GetByBusinessIdAsync(int businessId);
}
