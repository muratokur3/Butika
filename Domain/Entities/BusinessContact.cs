using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BusinessContact
{
    public int Id { get; set; }
    public int BusinessId { get; set; }
    public string ContactType { get; set; } = string.Empty; // e.g., "Email", "Phone"
    public string ContactValue { get; set; } = string.Empty; // e.g., email address or phone number
    public string Department { get; set; } = string.Empty; // e.g., "Sales", "Support"
    public bool Preferred { get; set; }

    // Navigation Property
    public Business Business { get; set; } = null!;
}