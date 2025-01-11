
using Infrastructure.Context;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Infrastructure.Repositorys.ConcreteRepositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

  
    private  UserRepository _userRepository;

    private  BusinessRepository _businessRepository;

    public IUserRepository Users => _userRepository ??= new UserRepository(_context);
    public IBusinessRepository Businesses => _businessRepository ??= new BusinessRepository(_context);


    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}