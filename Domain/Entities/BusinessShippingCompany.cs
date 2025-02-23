using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BusinessShippingCompany
{
    public int BusinessId { get; set; }
    public int ShippingCompanyId { get; set; }

    // Navigation Properties
    public Business Business { get; set; } = null!;
    public ShippingCompany ShippingCompany { get; set; } = null!;
}