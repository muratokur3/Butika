

using Application.Models.DTOs.Business;
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

    public async Task AddBusinessAsync(RegisterBusinessDTO registerBusinessDTO)
    {
        var business = _mapper.Map<Business>(registerBusinessDTO);
        await _unitOfWork.Businesses.AddAsync(business);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<BusinessDetailVM> UpdateBusinessBasicInfoAsync(BusinessBasicInfoDTO businessBasicInfoDTO)
    {
        var existingBusiness = await _unitOfWork.Businesses.GetByIdAsync(businessBasicInfoDTO.Id);
        if (existingBusiness == null)
        {
            throw new Exception("Business not found");
        }

        var a = _mapper.Map(businessBasicInfoDTO, existingBusiness);

        var updatedBusiness = await _unitOfWork.Businesses.UpdateBusinessBasicInfoAsync(a);
        await _unitOfWork.CompleteAsync();
        var businessVM = _mapper.Map<BusinessDetailVM>(updatedBusiness);

        return businessVM;

    }


    public async Task<IEnumerable<BusinessVM>> GetAllBusinessesAsync()
    {
        var businesses = await _unitOfWork.Businesses.GetAllAsync();
        return _mapper.Map<IEnumerable<BusinessVM>>(businesses);
    }
}
