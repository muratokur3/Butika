using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.AbstractRepositories;
public interface IUnitOfWork: IAsyncDisposable
{
    IUserRepository Users { get; }
    IBusinessRepository Businesses { get; }
    Task<int> CompleteAsync();
}
