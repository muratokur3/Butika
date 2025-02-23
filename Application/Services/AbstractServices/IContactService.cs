using Application.Models.DTOs.Contact;

namespace Application.Services.AbstractServices;

public interface IContactService
{
    Task CreateAsync(ContactDTO contactDTO);
    Task UpdateAsync(ContactDTO contactDTO);
}
