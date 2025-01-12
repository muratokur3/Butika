using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ShippingCompany
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation Property
    public ICollection<BusinessShippingCompany> BusinessShippingCompanies { get; set; } = new List<BusinessShippingCompany>();
}