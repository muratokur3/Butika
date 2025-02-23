using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class MarketplaceRepository : Repository<Marketplace>, IMarketplaceRepository
{
    public MarketplaceRepository(DbContext context) : base(context)
    {
    }
}
