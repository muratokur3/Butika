using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.Branch;

public class BranchDTO
{
    public int Id { get; set; }
    public int BusinessId { get; set; }
    public string Location { get; set; }
}
