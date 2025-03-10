﻿
namespace Domain.Entities;
public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }=null!;

    // Navigation Property
    public ICollection<BusinessTag> BusinessTags { get; set; } = new List<BusinessTag>();
}