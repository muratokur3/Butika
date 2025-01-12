using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.AbstractRepositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
        Task<IEnumerable<User>> FindByRoleAsync(string role);
        Task UpdatePasswordAsync(int userId, string newPassword);
        Task ActivateUserAsync(int userId);

    }
}
