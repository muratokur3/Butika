using Domain.Entities;

namespace Infrastructure.Repositorys.AbstractRepositories
{
    public interface IBranchRepository:IRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetBranchesForBusinessAsync(int businessId);
    }
}
