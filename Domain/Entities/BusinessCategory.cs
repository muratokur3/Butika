using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BusinessCategory
{
    public int Id { get; set; }
    public int BusinessId { get; set; }
    public int CategoryId { get; set; }

    // Navigation Properties
    public Business Business { get; set; } = null!;
    public Category Category { get; set; } = null!;
}