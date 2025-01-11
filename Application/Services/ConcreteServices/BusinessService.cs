

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
    public async Task<List<BusinessDto>> GetAllBusinessesAsync()
    {
        var businesses = await _unitOfWork.Businesses.GetAllAsync();
        return _mapper.Map<List<BusinessDto>>(businesses);
    }
    public async Task<BusinessDto> GetBusinessByIdAsync(int id)
    {
        var business = await _unitOfWork.Businesses.GetByIdAsync(id);
        if (business == null)
            return null;

        return _mapper.Map<BusinessDto>(business);
    }
    public async Task AddBusinessAsync(AddBusinessDto businessDto)
    {
        var business = _mapper.Map<Business>(businessDto);
        await _unitOfWork.Businesses.AddAsync(business);
    }

    public async Task UpdateBusinessAsync(UpdateBusinessDto businessDto)
    {
        var business = await _unitOfWork.Businesses.GetByIdAsync(businessDto.Id);
        if (business != null)
        {
            _mapper.Map(businessDto, business); // DTO'dan Entity'ye dönüşüm
            await _unitOfWork.Businesses.UpdateAsync(business);
        }
    }

    public async Task DeleteBusinessAsync(int id)
    {
        var business = await _unitOfWork.Businesses.GetByIdAsync(id);
        if (business != null)
        {
            await _unitOfWork.Businesses.DeleteAsync(business);
        }
    }

    public async Task<List<BusinessDto>> GetBusinessByTagAsync(string tag)
    {
        var businesses = await _unitOfWork.Businesses.GetAllAsync();
        var filteredBusinesses = businesses
            .Where(b => b.Tags.Any(t => t.Name.Contains(tag)))
            .ToList();

        return _mapper.Map<List<BusinessDto>>(filteredBusinesses);
    }

    public async Task<List<BusinessDto>> SearchBusinessesAsync(string searchTerm)
    {
        var businesses = await _unitOfWork.Businesses.GetAllAsync();
        var filteredBusinesses = businesses
            .Where(b => b.Name.Contains(searchTerm) || b.ShortDescription.Contains(searchTerm))
            .ToList();

        return _mapper.Map<List<BusinessDto>>(filteredBusinesses);
    }

    public async Task<BusinessWithTagsVm> GetBusinessWithTagsAsync(int businessId)
    {
        var business = await _unitOfWork.Businesses.GetByIdAsync(businessId);
        if (business == null)
        {
            return null;
        }

        var businessWithTagsVm = _mapper.Map<BusinessWithTagsVm>(business);
        return businessWithTagsVm;
    }

    public async Task<int> CountBusinessesAsync()
    {
        var count = await _unitOfWork.Businesses.CountAsync();
        return count;
    }
    public async Task<bool> ValidateBusinessDataAsync(AddBusinessDto businessDto)
    {
        var existingBusinesses = await _unitOfWork.Businesses.GetAllAsync();
        return existingBusinesses.All(b => b.Email != businessDto.Email && b.Name != businessDto.Name);
    }

    public async Task<List<BusinessDto>> GetBusinessesByOwnerAsync(int ownerId)
    {
        var businesses = await _unitOfWork.Businesses.GetAllAsync();
        var filteredBusinesses = businesses
            .Where(b => b.OwnerId == ownerId)
            .ToList();

        return _mapper.Map<List<BusinessDto>>(filteredBusinesses);
    }

}
