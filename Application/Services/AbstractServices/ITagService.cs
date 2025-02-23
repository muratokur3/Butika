using Application.Models.DTOs.Tag;

namespace Application.Services.AbstractServices
{
    public interface ITagService
    {
        Task CreateAsync(TagDTO tagDTO);
        Task UpdateAsync(TagDTO tagDTO);

    }
}
