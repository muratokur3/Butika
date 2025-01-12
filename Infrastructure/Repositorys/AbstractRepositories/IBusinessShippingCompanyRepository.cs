using Domain.Entities;

namespace Infrastructure.Repositorys.AbstractRepositories;

public interface IBusinessShippingCompanyRepository: IRepository<BusinessShippingCompany>
{
    Task<IEnumerable<ShippingCompany>> GetShippingCompaniesForBusinessAsync(int businessId);
    Task<IEnumerable<Business>> GetBusinessesForShippingCompanyAsync(int shippingCompanyId);

}
