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

public class BusinessRepository: Repository<Business>, IBusinessRepository
{
    public BusinessRepository(AppDbContext ctx) : base(ctx)
    {
    }
    private AppDbContext AppDbContext
    {
        get { return context as AppDbContext; }
    }
    // Etiket ile işletmeleri al
    public async Task<List<Business>> GetByTagAsync(string tag)
    {
        return await AppDbContext.Businesses
            .Where(b => b.Tags.Any(t => t.Name == tag))
            .Include(b => b.Tags)  // Tags ilişkisini dahil et
            .ToListAsync();
    }

    // Arama terimi ile işletmeleri al
    public async Task<List<Business>> SearchAsync(string searchTerm)
    {
        return await AppDbContext.Businesses
            .Where(b => b.Name.Contains(searchTerm) || b.ShortDescription.Contains(searchTerm))
            .Include(b => b.Tags)  // Tags ilişkisini dahil et
            .ToListAsync();
    }

    // İşletme sayısını al
    public async Task<int> CountAsync()
    {
        return await AppDbContext.Businesses.CountAsync();
    }
}
