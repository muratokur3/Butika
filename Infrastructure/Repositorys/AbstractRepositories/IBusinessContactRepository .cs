using Domain.Entities;


namespace Infrastructure.Repositorys.AbstractRepositories;

public interface IBusinessContactRepository:IRepository<BusinessContact>
{
    Task<List<BusinessContact>> GetByBusinessIdAsync(int businessId);
    Task<BusinessContact> GetPrimaryContactAsync(int businessId);

}
