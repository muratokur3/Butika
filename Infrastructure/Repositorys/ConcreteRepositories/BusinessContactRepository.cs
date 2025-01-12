using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class BusinessContactRepository : Repository<BusinessContact>, IBusinessContactRepository
{
    public BusinessContactRepository(DbContext context) : base(context) { }

    public Task<List<BusinessContact>> GetByBusinessIdAsync(int businessId)
    {
        throw new NotImplementedException();
    }

    public Task<BusinessContact> GetPrimaryContactAsync(int businessId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateContactAsync(int contactId, string newContactValue)
    {
        throw new NotImplementedException();
    }
}
