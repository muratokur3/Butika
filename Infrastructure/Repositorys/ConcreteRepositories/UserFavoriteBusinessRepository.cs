using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;
public class UserFavoriteBusinessRepository : Repository<UserFavoriteBusiness>, IUserFavoriteBusinessRepository
{
    public UserFavoriteBusinessRepository(DbContext context) : base(context) { }

   

    public async Task<IEnumerable<Business>> GetFavoriteBusinessesAsync(int userId)
    {
        var user = await _dbSet.FindAsync(userId);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        return await _context.Set<UserFavoriteBusiness>()
            .Where(ufb => ufb.UserId == userId)
            .Include(ufb => ufb.Business)
            .Select(ufb => ufb.Business)
            .ToListAsync();
    }

    public async Task RemoveFavoriteAsync(int userId, int businessId)
    {
        var favorite = await _context.Set<UserFavoriteBusiness>()
            .FirstOrDefaultAsync(ufb => ufb.UserId == userId && ufb.BusinessId == businessId);

        if (favorite == null)
        {
            throw new KeyNotFoundException("Favorite not found.");
        }

        _context.Set<UserFavoriteBusiness>().Remove(favorite);
        await _context.SaveChangesAsync();
    }
}
