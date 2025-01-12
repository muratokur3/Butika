using Application.Models.DTOs;
using Application.Models.VMs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AbstractServices;
public interface IBusinessService
{
    Task<IEnumerable<BusinessVm>> GetAllBusinessesAsync();
    Task<BusinessDto> GetBusinessByIdAsync(int id);
    Task<BusinessVm> AddBusinessAsync(AddBusinessDto addBusinessDto);
    Task<BusinessVm> UpdateBusinessAsync(UpdateBusinessDto businessDto);
    Task DeleteBusinessAsync(int id);
    Task<List<BusinessVm>> GetBusinessByTagAsync(string tag);
    Task<List<BusinessVm>> SearchBusinessesAsync(string searchTerm);
    Task<int> CountBusinessesAsync();
}
