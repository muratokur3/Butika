using Application.Models.DTOs.Certification;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;

public class CertificationService : ICertificationService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CertificationService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(CertificationDTO certificationDTO)
    {
        var certification = _mapper.Map<SpecialCertification>(certificationDTO);
        await _unitOfWork.Certifications.AddAsync(certification);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(CertificationDTO certificationDTO)
    {
        var certification = _mapper.Map<SpecialCertification>(certificationDTO);
         _unitOfWork.Certifications.Update(certification);
        await _unitOfWork.CompleteAsync();
    }
}
