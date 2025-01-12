using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.ConcreteRepositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public async Task ActivateUserAsync(int userId)
        {
            var user = await _context.Set<User>().FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            user.IsActive = true; 
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            return user;
        }

        public async Task<IEnumerable<User>> FindByRoleAsync(string role)
        {
            var users = await _context.Set<User>().Where(u => u.Role == role).ToListAsync();
            return users;
        }

        public async Task UpdatePasswordAsync(int userId, string newPassword)
        {
            var user = await _context.Set<User>().FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            user.PasswordHash = newPassword; // Şifreyi hashleyerek atamanız önerilir
            await _context.SaveChangesAsync();
        }
    }
}
