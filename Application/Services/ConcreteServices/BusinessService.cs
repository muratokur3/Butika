

using Application.Models.DTOs;
using Application.Models.VMs;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;
public class BusinessService : IBusinessService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BusinessService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BusinessVm> AddBusinessAsync(AddBusinessDto addBusinessDto)
    {
        var business = _mapper.Map<Business>(addBusinessDto);
       var newBusiness= await _unitOfWork.Businesses.AddAsync(business);
        return _mapper.Map<BusinessVm>(newBusiness);
    }

    public Task<int> CountBusinessesAsync()
    {
        return _unitOfWork.Businesses.CountAsync();
    }

    public async Task DeleteBusinessAsync(int id)
    {
        var entity = await _unitOfWork.Businesses.GetByIdAsync(id);
        await _unitOfWork.Businesses.DeleteAsync(entity);
    }

    public async Task<IEnumerable<BusinessVm>> GetAllBusinessesAsync()
    {
        var businesses = await _unitOfWork.Businesses.GetAllAsync();
        return _mapper.Map<IEnumerable<BusinessVm>>(businesses);
    }

    public async Task<BusinessDto> GetBusinessByIdAsync(int id)
    {
        var entity = await _unitOfWork.Businesses.GetByIdAsync(id);
        return _mapper.Map<BusinessDto>(entity);
    }

    public async Task<List<BusinessVm>> GetBusinessByTagAsync(string tag)
    {
        var businesses = _unitOfWork.Businesses.GetByTagAsync(tag);
        return await Task.FromResult(_mapper.Map<List<BusinessVm>>(businesses));
    }

    public Task<List<BusinessVm>> SearchBusinessesAsync(string searchTerm)
    {
        var businesses = _unitOfWork.Businesses.SearchAsync(searchTerm);
        return Task.FromResult(_mapper.Map<List<BusinessVm>>(businesses));
    }

    public Task<BusinessVm> UpdateBusinessAsync(UpdateBusinessDto businessDto)
    {
        var business = _mapper.Map<Business>(businessDto);
        var updatedBusiness = _unitOfWork.Businesses.UpdateAsync(business);
        return Task.FromResult(_mapper.Map<BusinessVm>(updatedBusiness));
    }
}
