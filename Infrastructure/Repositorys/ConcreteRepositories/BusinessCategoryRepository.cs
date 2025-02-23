using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys.ConcreteRepositories
{
    public class BusinessCategoryRepository : Repository<BusinessCategory>, IBusinessCategoryRepository
    {
        public BusinessCategoryRepository(DbContext context) : base(context) { }

        public Task AddCategoryToBusinessAsync(BusinessCategory businessCategory)
        {
            throw new NotImplementedException();
        }

        public Task<Business> GetBusinessByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BusinessCategory>> GetCategoriesForBusinessAsync(int businessId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCategoryFromBusinessAsync(BusinessCategory businessCategory)
        {
            throw new NotImplementedException();
        }
    }
}
