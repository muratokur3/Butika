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

        public Task RemoveCategoryFromBusinessAsync(BusinessCategory businessCategory)
        {
            throw new NotImplementedException();
        }
    }
}
