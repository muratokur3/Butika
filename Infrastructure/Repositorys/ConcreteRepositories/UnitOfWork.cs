
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private readonly IDictionary<Type, object> _repositories = new Dictionary<Type, object>();
    private readonly IBusinessRepository _businessRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IBusinessCategoryRepository _businessCategoryRepository;
    private readonly IBusinessContactRepository _businessContactRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IBusinessTagRepository _businessTagRepository;
    private readonly IBusinessMarketplaceRepository _businessMarketplaceRepository;
    private readonly IShippingCompanyRepository _shippingCompanyRepository;
    private readonly IBusinessShippingCompanyRepository _businessShippingCompanyRepository;
    private readonly ICampaignRepository _campaignRepository;
    private readonly IBusinessCampaignRepository _businessCampaignRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IUserFavoriteBusinessRepository _setFavoriteBusinesses;

    public UnitOfWork(DbContext context, IBusinessRepository businessRepository, IUserRepository userRepository, ICategoryRepository categoryRepository,
        IBusinessCategoryRepository businessCategoryRepository,
        IBusinessContactRepository businessContactRepository,
        ITagRepository tagRepository,
        IBusinessTagRepository businessTagRepository,
        IBusinessMarketplaceRepository businessMarketplaceRepository,
        IShippingCompanyRepository shippingCompanyRepository,
        IBusinessShippingCompanyRepository businessShippingCompanyRepository,
        ICampaignRepository campaignRepository,
        IBusinessCampaignRepository businessCampaignRepository,
        IBranchRepository branchRepository, IUserFavoriteBusinessRepository userFavoriteBusinesses)
    {
        _context = context;
        _businessRepository = businessRepository;
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
        _businessCategoryRepository = businessCategoryRepository;
        _businessContactRepository = businessContactRepository;
        _tagRepository = tagRepository;
        _businessTagRepository = businessTagRepository;
        _businessMarketplaceRepository = businessMarketplaceRepository;
        _shippingCompanyRepository = shippingCompanyRepository;
        _businessShippingCompanyRepository = businessShippingCompanyRepository;
        _campaignRepository = campaignRepository;
        _businessCampaignRepository = businessCampaignRepository;
        _branchRepository = branchRepository;
        _setFavoriteBusinesses = userFavoriteBusinesses;
    }

    public IBusinessRepository BusinessRepository => _businessRepository ?? new BusinessRepository(_context);
    public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
    public ICategoryRepository CategoryRepository => _categoryRepository?? new CategoryRepository(_context);
    public IBusinessCategoryRepository BusinessCategoryRepository => _businessCategoryRepository ?? new BusinessCategoryRepository(_context);
    public IBusinessContactRepository BusinessContactRepository => _businessContactRepository?? new BusinessContactRepository(_context);
    public ITagRepository TagRepository => _tagRepository?? new TagRepository(_context);
    public IBusinessTagRepository BusinessTagRepository => _businessTagRepository?? new BusinessTagRepository(_context);
    public IBusinessMarketplaceRepository BusinessMarketplaceRepository => _businessMarketplaceRepository?? new BusinessMarketplaceRepository(_context);
    public IShippingCompanyRepository ShippingCompanyRepository => _shippingCompanyRepository?? new ShippingCompanyRepository(_context);
    public IBusinessShippingCompanyRepository BusinessShippingCompanyRepository => _businessShippingCompanyRepository?? new BusinessShippingCompanyRepository(_context);
    public ICampaignRepository CampaignRepository => _campaignRepository?? new CampaignRepository(_context);
    public IBusinessCampaignRepository BusinessCampaignRepository => _businessCampaignRepository?? new BusinessCampaignRepository(_context);
    public IBranchRepository BranchRepository => _branchRepository?? new BranchRepository(_context);
    public IUserFavoriteBusinessRepository UserFavoriteBusinesses => _serFavoriteBusinesses?? new UserFavoriteBusinessRepository(_context);

    public IRepository<T> Repository<T>() where T : class
    {
        if (_repositories.ContainsKey(typeof(T)))
        {
            return (IRepository<T>)_repositories[typeof(T)];
        }

        var repositoryType = typeof(Repository<>).MakeGenericType(typeof(T));

        if (typeof(T) == typeof(Business))
        {
            repositoryType = typeof(BusinessRepository);
        }
        else if (typeof(T) == typeof(User))
        {
            repositoryType = typeof(UserRepository);
        }

        var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
        _repositories.Add(typeof(T), repositoryInstance);

        return (IRepository<T>)repositoryInstance;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}