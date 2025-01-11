using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.VMs;
public class UserVm
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public List<BusinessSummaryVm> Businesses { get; set; }
}