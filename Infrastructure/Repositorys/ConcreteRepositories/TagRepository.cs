using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class TagRepository : Repository<Tag>, ITagRepository
{
    public TagRepository(DbContext context) : base(context) { }

    public Task<List<Tag>> GetByBusinessIdAsync(int businessId)
    {
        throw new NotImplementedException();
    }
}
