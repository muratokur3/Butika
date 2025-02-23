using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.AbstractRepositories;
public interface IUnitOfWork: IAsyncDisposable
{
    //IRepository<T> Repository<T>() where T : class;
    IBusinessRepository Businesses { get; }
    IUserRepository Users { get; }
    IUserFavoriteBusinessRepository UserFavoriteBusinesses { get; }
    ICategoryRepository Categories { get; }
    IBusinessCategoryRepository BusinessCategories { get; }
    IBusinessContactRepository BusinessContacts{ get; }
    ITagRepository Tags { get; }
    IBusinessTagRepository BusinessTags { get; }
    IMarketplaceRepository marketplaces { get; }
    IBusinessMarketplaceRepository BusinessMarketplaces{ get; }
    IShippingCompanyRepository ShippingCompanys { get; }
    IBusinessShippingCompanyRepository BusinessShippingCompanys { get; }
    IMarketingChannelRepository MarketingChannels { get; }
    IHighlightFeatureRepository HighlightFeatures { get; }
    ICertificationRepository Certifications { get; }
    ICampaignRepository Campaigns { get; }
    IBusinessCampaignRepository BusinessCampaigns { get; }
    IBranchRepository Branchs { get; }
    Task CompleteAsync();
}
