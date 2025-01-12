
namespace Domain.Entities;
public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation Property
    public ICollection<BusinessTag> BusinessTags { get; set; } = new List<BusinessTag>();
}