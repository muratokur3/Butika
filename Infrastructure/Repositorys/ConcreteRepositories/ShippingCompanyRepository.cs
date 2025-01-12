using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class ShippingCompanyRepository:Repository<ShippingCompany>, IShippingCompanyRepository
{
    public ShippingCompanyRepository(DbContext context) : base(context) { }

    public Task<List<ShippingCompany>> GetByBusinessIdAsync(int businessId)
    {
        throw new NotImplementedException();
    }
}
