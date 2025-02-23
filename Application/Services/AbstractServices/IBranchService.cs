using Application.Models.DTOs.Branch;

namespace Application.Services.AbstractServices;

public interface IBranchService
{
    Task CreateAsync(BranchDTO branchDTO);
    Task UpdateAsync(BranchDTO branchDTO);
}
