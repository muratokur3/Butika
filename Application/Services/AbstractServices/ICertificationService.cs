using Application.Models.DTOs.Certification;

namespace Application.Services.AbstractServices;

public interface ICertificationService
{
    Task CreateAsync(CertificationDTO certificationDTO);
    Task UpdateAsync(CertificationDTO certificationDTO);
}
