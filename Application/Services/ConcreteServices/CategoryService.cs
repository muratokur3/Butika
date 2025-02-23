using Application.Models.DTOs.Category;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(CategoryDTO categoryDTO)
    {
        var category = _mapper.Map<Category>(categoryDTO);
        await _unitOfWork.Categories.AddAsync(category);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(CategoryDTO categoryDTO)
    {
        var category = _mapper.Map<Category>(categoryDTO);
        _unitOfWork.Categories.Update(category);
        await _unitOfWork.CompleteAsync();
    }
}
