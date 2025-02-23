
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;
public class UnitOfWork : IUnitOfWork
{

    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    

    private BusinessRepository _businesses;
    private UserRepository _users;
    private CategoryRepository _categories;
    private BusinessCategoryRepository _businessCategories;
    private BusinessContactRepository _businessContacts;
    private TagRepository _tags;
    private BusinessTagRepository _businessTags;
    private MarketplaceRepository _marketplaces;
    private BusinessMarketplaceRepository _businessMarketplaces;
    private ShippingCompanyRepository _shippingCompanys;
    private BusinessShippingCompanyRepository _businessShippingCompanys;
    private MarketingChannelRepository _marketingChannels;
    private HighlightFeatureRepository _highlightFeatures;
    private CertificationRepository _certifications;
    private CampaignRepository _campaigns;
    private BusinessCampaignRepository _businessCampaigns;
    private BranchRepository _branchs;
    private UserFavoriteBusinessRepository _userFavoriteBusinesses;


    public IBusinessRepository Businesses => _businesses ??= new BusinessRepository(_context);
    public IUserRepository Users => _users ??= new UserRepository(_context);
    public ICategoryRepository Categories => _categories ??= new CategoryRepository(_context);
    public IBusinessCategoryRepository BusinessCategories => _businessCategories ??= new BusinessCategoryRepository(_context);
    public IBusinessContactRepository BusinessContacts => _businessContacts ??= new BusinessContactRepository(_context);
    public ITagRepository Tags => _tags ??= new TagRepository(_context);
    public IBusinessTagRepository BusinessTags => _businessTags ??= new BusinessTagRepository(_context);
    public IMarketplaceRepository marketplaces => _marketplaces ??= new MarketplaceRepository(_context);
    public IBusinessMarketplaceRepository BusinessMarketplaces => _businessMarketplaces ??= new BusinessMarketplaceRepository(_context);
    public IShippingCompanyRepository ShippingCompanys => _shippingCompanys ??= new ShippingCompanyRepository(_context);
    public IBusinessShippingCompanyRepository BusinessShippingCompanys => _businessShippingCompanys ??= new BusinessShippingCompanyRepository(_context);
    public IMarketingChannelRepository MarketingChannels => _marketingChannels ??= new MarketingChannelRepository(_context);
    public IHighlightFeatureRepository HighlightFeatures => _highlightFeatures ??=new HighlightFeatureRepository(_context);
    public ICertificationRepository Certifications => _certifications ??= new CertificationRepository(_context);
    public ICampaignRepository Campaigns => _campaigns ??= new CampaignRepository(_context);
    public IBusinessCampaignRepository BusinessCampaigns => _businessCampaigns ??= new BusinessCampaignRepository(_context);
    public IBranchRepository Branchs => _branchs ??= new BranchRepository(_context);
    public IUserFavoriteBusinessRepository UserFavoriteBusinesses => _userFavoriteBusinesses ??= new UserFavoriteBusinessRepository(_context);

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}