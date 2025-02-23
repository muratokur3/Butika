using Application.Models.DTOs.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.Tag;

public class BusinessTagDTO
{
    public int BusinessId { get; set; }
    public int TagId { get; set; }
    public TagDTO TagDTO { get; set; }
}
