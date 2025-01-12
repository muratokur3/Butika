

namespace Domain.Entities;
public class UserFavoriteBusiness
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;  

    public int BusinessId { get; set; }
    public Business Business { get; set; } = null!;  

    public DateTime AddedDate { get; set; } = DateTime.UtcNow; 
}
