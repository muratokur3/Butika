using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.Contact;

public class ContactDTO
{
    public int Id { get; set; }
    public int BusinessId { get; set; }
    public ContactType ContactType { get; set; } = 0;
    public string ContactValue { get; set; }
    public Department Department { get; set; } = 0;
    public bool Preferred { get; set; }
}
