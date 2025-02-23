using Application.Models.DTOs.Branch;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;

public class BranchService : IBranchService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public BranchService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(BranchDTO branchDTO)
    {
        var branch = _mapper.Map<Branch>(branchDTO);
        await _unitOfWork.Branchs.AddAsync(branch);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(BranchDTO branchDTO)
    {
        var branch = _mapper.Map<Branch>(branchDTO);
        _unitOfWork.Branchs.Update(branch);
        await _unitOfWork.CompleteAsync();
    }
}
