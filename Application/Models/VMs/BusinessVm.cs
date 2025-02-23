using Application.Models.DTOs.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.VMs;
public class BusinessVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
