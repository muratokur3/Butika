

using Domain.Entities;

namespace Infrastructure.Repositorys.AbstractRepositories;

public interface IUserFavoriteBusinessRepository : IRepository<UserFavoriteBusiness>
{
    Task<IEnumerable<Business>> GetFavoriteBusinessesAsync(int userId);
    Task<int> GetUserFavoriteBusinessesCountAsync(int userId);
    Task<int> GetBussinesFavoritesCountAsync(int businessId);
    Task<bool> IsUserFavoriteBusinessAsync(UserFavoriteBusiness userFavoriteBusiness);

}
