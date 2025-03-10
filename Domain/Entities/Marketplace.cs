﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Marketplace
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    // Navigation Property
    public ICollection<BusinessMarketplace> BusinessMarketplaces { get; set; } = new List<BusinessMarketplace>();
}