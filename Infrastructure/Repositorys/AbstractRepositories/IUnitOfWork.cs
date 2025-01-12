using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.AbstractRepositories;
public interface IUnitOfWork: IAsyncDisposable
{
    IRepository<T> Repository<T>() where T : class;
    IBusinessRepository BusinessRepository { get; }
    IUserRepository UserRepository { get; }
    IUserFavoriteBusinessRepository UserFavoriteBusinesses { get; }
    ICategoryRepository CategoryRepository { get; }
    IBusinessCategoryRepository BusinessCategoryRepository { get; }
    IBusinessContactRepository BusinessContactRepository { get; }
    ITagRepository TagRepository { get; }
    IBusinessTagRepository BusinessTagRepository { get; }
    IBusinessMarketplaceRepository BusinessMarketplaceRepository { get; }
    IShippingCompanyRepository ShippingCompanyRepository { get; }
    IBusinessShippingCompanyRepository BusinessShippingCompanyRepository { get; }
    ICampaignRepository CampaignRepository { get; }
    IBusinessCampaignRepository BusinessCampaignRepository { get; }
    IBranchRepository BranchRepository { get; }
    Task CompleteAsync();
}
