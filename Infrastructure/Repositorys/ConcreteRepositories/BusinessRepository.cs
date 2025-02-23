using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.ConcreteRepositories;

public class BusinessRepository : Repository<Business>, IBusinessRepository
{
    public BusinessRepository(DbContext context) : base(context) { }


    public async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }

    public async Task<IEnumerable<Business>> FindByApprovalStatusAsync(bool approvalStatus)
    {
        throw new NotImplementedException();
    }
    public async Task<Business> GetBusinessWithDetailsAsync(int businessId)
    {
        return await _dbSet
            .Include(b => b.Contacts)
            .Include(b => b.BusinessTags).ThenInclude(bt => bt.Tag)
            .Include(b => b.BusinessMarketplaces).ThenInclude(bm => bm.Marketplace)
            .Include(b => b.BusinessShippingCompanies).ThenInclude(bsc => bsc.ShippingCompany)
            .Include(b => b.BusinessCampaigns).ThenInclude(bc => bc.Campaign)
            .Include(b => b.BusinessSpecialCertifications).ThenInclude(bsc => bsc.SpecialCertification)
            .Include(b => b.BusinessHighlightFeatures).ThenInclude(bhf => bhf.HighlightFeature)
            .Include(b => b.BusinessMarketingChannels).ThenInclude(bmc => bmc.MarketingChannel)
            .Include(b => b.Branches)
            .Include(b => b.BusinessCategories).ThenInclude(bc => bc.Category)
            .FirstOrDefaultAsync(b => b.Id == businessId);
    }

    public async Task<List<Business>> GetByTagAsync(string tag)
    {
        return await _dbSet
            .Where(b => b.BusinessTags.Any(bt => bt.Tag.Name == tag))
            .ToListAsync();
    }
    public async Task<List<Business>> SearchAsync(string searchTerm)
    {
        return await _dbSet
            .Where(b => b.Name.Contains(searchTerm) || b.Description.Contains(searchTerm))
            .ToListAsync();
    }

    public async Task UpdateApprovalStatusAsync(int businessId, bool approvalStatus)
    {
        throw new NotImplementedException();
    }

    public async Task<Business> UpdateBusinessBasicInfoAsync(Business entity)
    {
       return await Task.FromResult(_dbSet.Update(entity).Entity);
    }
}
