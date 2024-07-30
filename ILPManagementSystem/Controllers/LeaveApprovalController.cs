using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveApprovalController : ControllerBase
    {
        private readonly ILeaveApprovalRepository _leaveApprovalRepository;

        public LeaveApprovalController(ILeaveApprovalRepository leaveApprovalRepository)
        {
            _leaveApprovalRepository = leaveApprovalRepository;
        }


        [HttpGet("{leaveId}")]
        public async Task<ActionResult<LeaveApproval>> GetApproval(int leaveId)
        {
            var approval = await _leaveApprovalRepository.GetApprovalsByLeaveIdAsync(leaveId);
            if (approval == null) return NotFound();
            return Ok(approval);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveApproval>>> GetApprovals()
        {
            var approvals = await _leaveApprovalRepository.GetAllApprovalsAsync();
            return Ok(approvals);
        }

        [HttpPost]
        public async Task<ActionResult<LeaveApproval>> PostApproval(LeaveApproval leaveApproval)
        {
            var createdApproval = await _leaveApprovalRepository.AddApprovalAsync(leaveApproval);
            return CreatedAtAction(nameof(GetApproval), new { id = createdApproval.Id }, createdApproval);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutApproval(int id, LeaveApproval leaveApproval)
        {
            if (id != leaveApproval.Id) return BadRequest();

            await _leaveApprovalRepository.UpdateApprovalAsync(leaveApproval);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApproval(int id)
        {
            var result = await _leaveApprovalRepository.DeleteApprovalAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}

