using Application.Models.DTOs.Category;

namespace Application.Services.AbstractServices;

public interface ICategoryService
{
    Task CreateAsync(CategoryDTO categoryDTO);
    Task UpdateAsync(CategoryDTO categoryDTO);
}
