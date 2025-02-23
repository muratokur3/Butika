using Application.Models.DTOs;
using Application.Models.DTOs.Business;
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
    Task<IEnumerable<BusinessVM>> GetAllBusinessesAsync();
    Task AddBusinessAsync(RegisterBusinessDTO registerBusinessDTO);
    Task<BusinessDetailVM> UpdateBusinessBasicInfoAsync(BusinessBasicInfoDTO businessBasicInfoDTO);
}
