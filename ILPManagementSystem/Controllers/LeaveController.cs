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
        private readonly ILeaveApprovalRepository _leaveApprovalRepository;

        public LeaveController(ILeaveRepository leavesRepository , ILeaveApprovalRepository leaveApprovalRepository)
        {
            _leaveRepository = leavesRepository;
            _leaveApprovalRepository = leaveApprovalRepository;
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

        [HttpGet("leaveRequests")]
        public async Task<ActionResult<IEnumerable<Leave>>> GetLeaveRequests()
        {
            var leaves = await _leaveRepository.GetAllLeavesAsync();
            var leaveRequests = new List<LeaveDTO>();

            foreach (var leave in leaves)
            {
                var approvals = await _leaveApprovalRepository.GetApprovalsByLeaveIdAsync(leave.Id);
                if (approvals.Any(a => a.IsApproved == null))
                {
                    leaveRequests.Add(new LeaveDTO
                    {
                        // Populate properties
                        Id = leave.Id,
                        /*TraineeId = Trainee.Id,*/
                        NumofDays = leave.NumofDays,
                        LeaveDate = leave.LeaveDate,
                        LeaveDateFrom = leave.LeaveDateFrom,
                        LeaveDateTo = leave.LeaveDateTo,
                        CreatedDate = leave.CreatedDate,
                        Reason = leave.Reason,
                        Description = leave.Description,
                        /*Trainee = leave.Trainee,*/
                        IsPending = true // Add a new property to track if the leave is pending
                    });
                }
                else
                {
                    leaveRequests.Add(new LeaveDTO
                    {
                        // Populate properties
                        Id = leave.Id,
                        /*TraineeId = leave.TraineeId,*/
                        NumofDays = leave.NumofDays,
                        LeaveDate = leave.LeaveDate,
                        LeaveDateFrom = leave.LeaveDateFrom,
                        LeaveDateTo = leave.LeaveDateTo,
                        CreatedDate = leave.CreatedDate,
                        Reason = leave.Reason,
                        Description = leave.Description,
                        /*Trainee = leave.Trainee,*/
                        IsPending = false // Add a new property to track if the leave is not pending
                    });
                }
            }

            return Ok(leaveRequests);
        }

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
                /*TraineeId = leaveDto.TraineeId,*/
                NumofDays = leaveDto.NumofDays,
                Reason = leaveDto.Reason,
                Description = leaveDto.Description,
                CreatedDate = DateTime.UtcNow,
            };

            if (leaveDto.NumofDays == 1)
            {
                if (leaveDto.LeaveDate.HasValue)
                {
                    leave.LeaveDate = (DateTime)leaveDto.LeaveDate;

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
                        IsApproved = null
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

        [HttpPut("updateApprovalStatus/{id}")]
        public async Task<ActionResult> UpdateApprovalStatus(int id, [FromBody] LeaveApproval leaveApproval)
        {
            var leave = await _leaveRepository.GetLeaveByIdAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            var existingApproval = await _leaveApprovalRepository.GetLeaveApprovalAsync(id, leaveApproval.userId);

            if (existingApproval == null)
            {
                await _leaveApprovalRepository.AddApprovalAsync(leaveApproval);
            }
            else
            {
                existingApproval.IsApproved = leaveApproval.IsApproved;
                await _leaveApprovalRepository.UpdateApprovalAsync(existingApproval);
            }

            return NoContent();
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
