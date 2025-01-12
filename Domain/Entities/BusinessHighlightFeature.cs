using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BusinessHighlightFeature
{
    public int Id { get; set; }
    public int BusinessId { get; set; }
    public int HighlightFeatureId { get; set; }

    // Navigation Properties
    public Business Business { get; set; } = null!;
    public HighlightFeature HighlightFeature { get; set; } = null!;
}