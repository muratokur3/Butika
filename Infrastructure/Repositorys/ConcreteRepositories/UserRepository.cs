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
        public UserRepository(AppDbContext ctx) : base(ctx)
        {
        }
        private AppDbContext AppDbContext
        {
            get { return context as AppDbContext; }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await AppDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
