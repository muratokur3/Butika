using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BusinessSpecialCertification
{
    public int BusinessId { get; set; }
    public int SpecialCertificationId { get; set; }

    // Navigation Properties
    public Business Business { get; set; } = null!;
    public SpecialCertification SpecialCertification { get; set; } = null!;
}