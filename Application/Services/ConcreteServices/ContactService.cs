using Application.Models.DTOs.Contact;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;

public class ContactService : IContactService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public ContactService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(ContactDTO contactDTO)
    {
        var contact = _mapper.Map<BusinessContact>(contactDTO);
        await _unitOfWork.BusinessContacts.AddAsync(contact);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(ContactDTO contactDTO)
    {
        var contact = _mapper.Map<BusinessContact>(contactDTO);
        _unitOfWork.BusinessContacts.Update(contact);
        await _unitOfWork.CompleteAsync();
    }
}
