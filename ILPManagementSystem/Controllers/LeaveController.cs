using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                var pocIds = approvals.Select(a => a.userId).ToList(); // Get the list of POC IDs

                // Fetch the trainee with batch information
                var trainee = await _leaveRepository.GetTraineeWithBatchByIdAsync(leave.TraineeId);
                var user = await _leaveRepository.GetUserByIdAsync(trainee.UserId);
                
                bool isPending = approvals.Any(a => a.IsApproved == null);

                if (approvals.Any(a => a.IsApproved == null))
                {
                    leaveRequests.Add(new LeaveDTO
                    {
                        Id = leave.Id,
                        Name = $"{user.FirstName} {user.LastName}", // Get the full name
                        NumofDays = leave.NumofDays,
                        LeaveDate = leave.LeaveDate,
                        LeaveDateFrom = leave.LeaveDateFrom,
                        LeaveDateTo = leave.LeaveDateTo,
                        CreatedDate = leave.CreatedDate,
                        Reason = leave.Reason,
                        Description = leave.Description,
                        PocIds = pocIds,
                        IsPending = true, // Check if any approval is pending
                        /*BatchName = trainee.Batch?.BatchName*/ // Include batch information

                    });
                }
                else
                {
                    leaveRequests.Add(new LeaveDTO
                    {
                        Id = leave.Id,
                        Name = $"{user.FirstName} {user.LastName}", // Get the full name
                        NumofDays = leave.NumofDays,
                        LeaveDate = leave.LeaveDate,
                        LeaveDateFrom = leave.LeaveDateFrom,
                        LeaveDateTo = leave.LeaveDateTo,
                        CreatedDate = leave.CreatedDate,
                        Reason = leave.Reason,
                        Description = leave.Description,
                        PocIds = pocIds,
                        IsPending = false, // Check if any approval is pending
                        /*BatchName = trainee.Batch?.BatchName*/ // Include batch information
                    });
                }
            }

            return Ok(leaveRequests);
        }

        [HttpPost]
        public async Task<IActionResult> PostLeaveRequest([FromBody] LeaveDTO leaveDto)
        {
            var trainee = await _leaveRepository.GetTraineeByFullNameAsync(leaveDto.Name);

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

        /* [HttpPut("updateApprovalStatus/{id}")]
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
         }*/

        /* [HttpPut("updateApprovalStatus/{id}")]
         public async Task<ActionResult> UpdateApprovalStatus(int id, [FromBody] LeaveApproval leaveApproval)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             var leave = await _leaveRepository.GetLeaveByIdAsync(id);
             if (leave == null)
             {
                 return NotFound();
             }

             var existingApproval = await _leaveApprovalRepository.GetLeaveApprovalAsync(id, leaveApproval.userId);
             if (existingApproval == null)
             {
                 leaveApproval.LeavesId = id; // Ensure the LeavesId is set correctly
                 await _leaveApprovalRepository.AddApprovalAsync(leaveApproval);
             }
             else
             {
                 existingApproval.IsApproved = leaveApproval.IsApproved;
                 await _leaveApprovalRepository.UpdateApprovalAsync(existingApproval);
             }

             return NoContent();
         }*/

        [HttpPut("updateApprovalStatus/{id}")]
        public async Task<ActionResult> UpdateApprovalStatus(int id, [FromBody] LeaveApprovalUpdateDTO leaveApprovalUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leave = await _leaveRepository.GetLeaveByIdAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            var existingApproval = await _leaveApprovalRepository.GetLeaveApprovalAsync(id, leaveApprovalUpdateDto.UserId);
            if (existingApproval == null)
            {
                var newApproval = new LeaveApproval
                {
                    LeavesId = id,
                    userId = leaveApprovalUpdateDto.UserId,
                    IsApproved = leaveApprovalUpdateDto.IsApproved
                };
                await _leaveApprovalRepository.AddApprovalAsync(newApproval);
            }
            else
            {
                existingApproval.IsApproved = leaveApprovalUpdateDto.IsApproved;
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
