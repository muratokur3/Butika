using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class BranchRepository : Repository<Branch>, IBranchRepository
{
    public BranchRepository(DbContext context) : base(context) { }

    public Task AddBranchToBusinessAsync(int businessId, Branch branch)
    {
       throw new NotImplementedException();
    }

    public Task<IEnumerable<Branch>> GetBranchesForBusinessAsync(int businessId)
    {
        throw new NotImplementedException();
    }
}
