using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    /*[Authorize(Policy = "AdminPolicy")]*/
    /*  [Authorize(Policy = "TrainerPolicy")]
        [Authorize(Policy = "TraineePolicy")]*/
    [Route("api/[controller]")]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveRepository _leaveRepository;

        public LeaveController(ILeaveRepository leavesRepository)
        {
            _leaveRepository = leavesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leave>>> GetLeaves()
        {
            var leaves = await _leaveRepository.GetAllLeavesAsync();
            return Ok(leaves);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Leave>> GetLeave(int id)
        {
            var leave = await _leaveRepository.GetLeaveByIdAsync(id);
            if (leave == null) return NotFound();
            return Ok(leave);
        }

        [HttpPost]
        public async Task<ActionResult<Leave>> PostLeave(Leave leave)
        {
            var createdLeave = await _leaveRepository.AddLeaveAsync(leave);
            return CreatedAtAction(nameof(GetLeave), new { id = createdLeave.Id }, createdLeave);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeave(int id, Leave leave)
        {
            if (id != leave.Id) return BadRequest();

            await _leaveRepository.UpdateLeaveAsync(leave);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            var result = await _leaveRepository.DeleteLeaveAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
