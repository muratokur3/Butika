using Domain.Enums;
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
    public ContactType ContactType { get; set; } = 0;
    public string ContactValue { get; set; }
    public Department Department { get; set; } = 0;
    public bool Preferred { get; set; }

    // Navigation Property
    public Business Business { get; set; } = null!;

}