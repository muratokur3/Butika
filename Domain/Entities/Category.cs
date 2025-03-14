﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation Property
    public ICollection<BusinessCategory> BusinessCategories { get; set; }
}