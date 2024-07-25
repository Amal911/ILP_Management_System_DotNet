using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
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

        /*[HttpPost]
        public async Task<ActionResult<Leave>> PostLeave(Leave leave)
        {
            var createdLeave = await _leaveRepository.AddLeaveAsync(leave);
            return CreatedAtAction(nameof(GetLeave), new { id = createdLeave.Id }, createdLeave);
        }*//*

        [HttpPost]
        *//*public async Task<IActionResult> PostLeaveRequest(LeaveDTO leaveDto)
        {
            var nameParts = leaveDto.Name.Split(' ');
            if (nameParts.Length < 2)
            {
                return BadRequest(new { message = "Invalid name format" });
            }

            var firstName = nameParts[0];
            var lastName = nameParts[1];

            var user = await _leaveRepository.GetUserByNameAsync(firstName, lastName);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            var trainee = await _leaveRepository.GetTraineeByUserIdAsync(user.Id);
            if (trainee == null)
            {
                return NotFound(new { message = "Trainee not found" });
            }

            var leave = new Leave
            {
                TraineeId = trainee.Id,
                NumofDays = leaveDto.NumofDays,
                LeaveDate = leaveDto.LeaveDate.ToUniversalTime(), // Convert to UTC
                LeaveDateFrom = leaveDto.LeaveDateFrom.ToUniversalTime(), // Convert to UTC
                LeaveDateTo = leaveDto.LeaveDateTo.ToUniversalTime(),
                Reason = leaveDto.Reason,
                Description = leaveDto.Description
            };

            await _leaveRepository.AddLeaveAsync(leave);

            return Ok(new { message = "Leave request created successfully" });
        }*/

        [HttpPost]
        public async Task<IActionResult> PostLeaveRequest([FromBody] LeaveDTO leaveDto)
        {
            var trainee = await _leaveRepository.GetTraineeByFirstNameAsync(leaveDto.Name);

            if (trainee == null)
            {
                return NotFound(new { message = "Trainee not found" });
            }

            var leave = new Leave
            {
                TraineeId = trainee.Id,
                NumofDays = leaveDto.NumofDays,
                Reason = leaveDto.Reason,
                Description = leaveDto.Description,
                CreatedDate = DateTime.UtcNow,
                /*LeaveDate = (DateTime)leaveDto.LeaveDate,
                LeaveDateFrom= (DateTime)leaveDto.LeaveDateFrom,
                LeaveDateTo= (DateTime)leaveDto.LeaveDateTo,*/
            };

            if (leaveDto.NumofDays == 1)
            {
                if (leaveDto.LeaveDate.HasValue)
                {
                    leave.LeaveDate = (DateTime)leaveDto.LeaveDate;
                    /*leaveDto.LeaveDateFrom = null;
                    leaveDto.LeaveDateTo = null;*/
                }
                else
                {
                    return BadRequest(new { message = "Leave date is required for 1 day leave" });
                }
            }
            else if (leaveDto.NumofDays > 1)
            {
                if (leaveDto.LeaveDateFrom.HasValue && leaveDto.LeaveDateTo.HasValue)
                {
                    leave.LeaveDateFrom = (DateTime)leaveDto.LeaveDateFrom;
                    leave.LeaveDateTo = (DateTime)leaveDto.LeaveDateTo;
                    /*leaveDto.LeaveDate = null;*/
                }
                else
                {
                    return BadRequest(new { message = "Leave date range is required for multiple days leave" });
                }
            }
            else
            {
                return BadRequest(new { message = "NumofDays must be greater than 0" });
            }

            try
            {
                await _leaveRepository.AddLeaveAsync(leave);

                foreach (var pocId in leaveDto.PocIds)
                {
                    var leaveApproval = new LeaveApproval
                    {
                        LeavesId = leave.Id,
                        userId = pocId,
                        IsApproved = false
                    };

                    await _leaveRepository.AddLeaveApprovalAsync(leaveApproval);
                }

                return Ok(new { message = "Leave request submitted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
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
