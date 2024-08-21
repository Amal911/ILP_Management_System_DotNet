using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Services.ValidationServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ILPManagementSystem.Controllers
{

    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceRepository _repository;
        private readonly AttendanceService _attendanceService;
        private IMapper _mapper;

        public AttendanceController(AttendanceRepository _repository, AttendanceService _attendanceService, IMapper _mapper)
        {
            this._repository = _repository;
            this._attendanceService = _attendanceService;
            this._mapper = _mapper;

        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendance()
        {
            try
            {
                var attendance = await _repository.GetAttendanceAsync();
                var response = new APIResponse
                {
                    IsSuccess = true,
                    Result = attendance,
                    StatusCode = HttpStatusCode.OK
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = new List<string> { $"Internal server error: {ex.Message}" }
                });
            }
        }



        [HttpPost]
        public async Task<ActionResult> AddAttendance([FromBody] PostAttendanceDTO postAttendanceDTO)
        {
            try
            {
                foreach (var data in postAttendanceDTO.Attendees)
                {
                    var attendance = _mapper.Map<Attendance>(data);
                    attendance.SessionId = postAttendanceDTO.SessionId;
                    await _repository.AddAttendance(attendance);
                }
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.Created,
                    Result = postAttendanceDTO,
                    Message = new List<string> { "Attendance added successfully" }
                };
                return CreatedAtAction(nameof(GetAttendance), new { }, postAttendanceDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = new List<string> { $"Internal server error: {ex.Message}" }
                });
            }
        }



        [HttpPut]
        public async Task<ActionResult> UpdateAttendance([FromBody] List<AttendanceDTO> attendanceList, [FromQuery] int sessionId)
        {
            if (attendanceList == null||!attendanceList.Any())
            {
                return BadRequest(new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = new List<string> { "Invalid attendance data" }
                });
            }
            try
            {
                var existingAttendances = await _repository.GetAttendanceBySessionIdAsync(sessionId);
                if (existingAttendances == null || !existingAttendances.Any())
                {
                    return BadRequest(new APIResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = new List<string> { "Invalid attendance data" }
                    });
                }
                foreach (var newAttendance in attendanceList)
                {
                    var existingAttendance = existingAttendances.FirstOrDefault(a => a.TraineeId == newAttendance.TraineeId);
                    if (existingAttendance != null) 
                    {
                        existingAttendance.IsPresent = newAttendance.IsPresent;
                        existingAttendance.Remarks = newAttendance.Remarks ?? string.Empty;
                        await _repository.UpdateAttendance(existingAttendance);

                    }

                }
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = attendanceList,
                    Message = new List<string> { "Attendance updated successfully" }
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = new List<string> { $"Internal server error: {ex.Message}" }
                });
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetAttendanceBySessionIdAsync(int id)
        {
            try
            {
                var attendance = await _repository.GetAttendanceBySessionIdAsync(id);
                if (attendance == null)
                {
                    return NotFound(new APIResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        Message = new List<string> { "Attendance not found" }
                    });
                }
                var response = new APIResponse
                {
                    IsSuccess = true,
                    Result = attendance,
                    StatusCode = HttpStatusCode.OK
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = new List<string> { $"Internal server error: {ex.Message}" }
                });
            }
        }
        
        
        
        [HttpDelete]
        public async Task<ActionResult> DeleteAttendance(int id)
        {
            try
            {
                await _repository.DeleteAttendance(id);
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.NoContent,
                    Message = new List<string> { "Attendance deleted successfully" }
                };
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = new List<string> { $"Internal server error: {ex.Message}" }
                });
            }


        }
    }
}
