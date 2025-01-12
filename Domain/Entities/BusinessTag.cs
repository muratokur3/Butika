using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BusinessTag
{
    public int Id { get; set; }
    public int BusinessId { get; set; }
    public int TagId { get; set; }

    // Navigation Properties
    public Business Business { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}