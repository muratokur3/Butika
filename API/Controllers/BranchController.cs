using Application.Models.DTOs.Branch;
using Application.Services.AbstractServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] BranchDTO branchDTO)
        {
            await _branchService.CreateAsync(branchDTO);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBranch([FromBody] BranchDTO branchDTO)
        {
            await _branchService.UpdateAsync(branchDTO);
            return Ok();
        }
    }
}
