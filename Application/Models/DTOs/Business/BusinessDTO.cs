using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.Business;
public class BusinessDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SummaryDescription { get; set; }
    public bool ApprovalStatus { get; set; }
}