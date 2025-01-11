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
    Task<List<BusinessDto>> GetAllBusinessesAsync();
    Task<BusinessDto> GetBusinessByIdAsync(int id);
    Task AddBusinessAsync(AddBusinessDto businessDto);
    Task UpdateBusinessAsync(UpdateBusinessDto businessDto);
    Task DeleteBusinessAsync(int id);
    Task<List<BusinessDto>> GetBusinessByTagAsync(string tag);
    Task<List<BusinessDto>> SearchBusinessesAsync(string searchTerm);
    Task<BusinessWithTagsVm> GetBusinessWithTagsAsync(int businessId);
    Task<int> CountBusinessesAsync();
    Task<bool> ValidateBusinessDataAsync(AddBusinessDto businessDto);
    Task<List<BusinessDto>> GetBusinessesByOwnerAsync(int ownerId);
}
