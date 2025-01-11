﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.AbstractRepositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
