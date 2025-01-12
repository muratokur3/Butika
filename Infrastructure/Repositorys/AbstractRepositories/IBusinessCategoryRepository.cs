using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.AbstractRepositories;

public interface IBusinessCategoryRepository:IRepository<BusinessCategory>
{
    Task<IEnumerable<BusinessCategory>> GetCategoriesForBusinessAsync(int businessId);
    Task<Business> GetBusinessByCategoryIdAsync(int categoryId);

}
