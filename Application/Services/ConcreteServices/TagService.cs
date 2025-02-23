using Application.Models.DTOs.Tag;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;

public class TagService : ITagService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public TagService( IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(TagDTO tagDTO)
    {
        var tag = _mapper.Map<Tag>(tagDTO);
        await _unitOfWork.Tags.AddAsync(tag);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(TagDTO tagDTO)
    {
        var tag = _mapper.Map<Tag>(tagDTO);
        _unitOfWork.Tags.Update(tag);
        await _unitOfWork.CompleteAsync();
    }
}
