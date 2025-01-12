using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Branch
{
    public int Id { get; set; }
    public int BusinessId { get; set; }
    public string Location { get; set; } = string.Empty;

    // Navigation Property
    public Business Business { get; set; } = null!;
}