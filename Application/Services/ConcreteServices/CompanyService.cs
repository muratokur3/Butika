using Application.Models.DTOs.ShippingCompany;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;

public class CompanyService : ICompanyService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CompanyService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(ShippingCompanyDTO shippingCompanyDTO)
    {
        var shippingCompany = _mapper.Map<ShippingCompany>(shippingCompanyDTO);
        await _unitOfWork.ShippingCompanys.AddAsync(shippingCompany);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(ShippingCompanyDTO shippingCompanyDTO)
    {
        var shippingCompany = _mapper.Map<ShippingCompany>(shippingCompanyDTO);
        _unitOfWork.ShippingCompanys.Update(shippingCompany);
        await _unitOfWork.CompleteAsync();
    }
}
