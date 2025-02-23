using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.ConcreteRepositories
{
    public class MarketingChannelRepository : Repository<MarketingChannel>, IMarketingChannelRepository
    {
        public MarketingChannelRepository(DbContext context) : base(context)
        {
        }
    }
}
