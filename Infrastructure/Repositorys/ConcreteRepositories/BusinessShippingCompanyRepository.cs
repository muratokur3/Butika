using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class BusinessShippingCompanyRepository : Repository<BusinessShippingCompany>, IBusinessShippingCompanyRepository
{
    public BusinessShippingCompanyRepository(DbContext context) : base(context) { }

    public Task<IEnumerable<Business>> GetBusinessesForShippingCompanyAsync(int shippingCompanyId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ShippingCompany>> GetShippingCompaniesForBusinessAsync(int businessId)
    {
        throw new NotImplementedException();
    }
}
