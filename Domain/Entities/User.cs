﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }

    // Navigation Property
    public ICollection<UserFavoriteBusiness> UserFavoriteBusinesses { get; set; } = new List<UserFavoriteBusiness>();
}
