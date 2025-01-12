using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.User;

public class LoginDto
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
