using Application.Models.DTOs.ShippingCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AbstractServices;

public interface ICompanyService
{
    Task CreateAsync(ShippingCompanyDTO shippingCompanyDTO);
    Task UpdateAsync(ShippingCompanyDTO shippingCompanyDTO);
}
