
using Domain.Entities;

namespace Infrastructure.Repositorys.AbstractRepositories;

public interface IBusinessTagRepository:IRepository<BusinessTag>
{
    Task<IEnumerable<Business>> GetBusinessesForTagAsync(int tagId);
    Task<IEnumerable<Tag>> GetTagsForBusinessAsync(int businessId);

}
