using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class SocialMediaLinks
{
    public int Id { get; set; }
    public string FacebookUrl { get; set; }
    public string TwitterUrl { get; set; }
    public string InstagramUrl { get; set; }
    public string LinkedInUrl { get; set; }
    public int BusinessId { get; set; }
    public Business Business { get; set; }
}
