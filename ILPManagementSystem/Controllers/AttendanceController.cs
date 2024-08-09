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

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateAttendance(AttendanceDTO newAttendance, int id)
        {
            if (newAttendance == null)
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
                Attendance UpdateAttendance = _mapper.Map<Attendance>(newAttendance);
                UpdateAttendance.Id = id;
                UpdateAttendance.Remarks=newAttendance.Remarks??string.Empty;
                await _repository.UpdateAttendance(UpdateAttendance);
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = UpdateAttendance,
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
        public async Task<ActionResult<Attendance>> GetAttendanceById(int id)
        {
            try
            {
                var attendance = await _repository.GetAttendanceByIdAsync(id);
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
