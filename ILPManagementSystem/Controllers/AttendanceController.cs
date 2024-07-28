using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Services.ValidationServices;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{

    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class AttendanceController:ControllerBase
    {
        private readonly AttendanceRepository _repository;
        private readonly  AttendanceService _attendanceService;
        private IMapper _mapper;

        public AttendanceController(ApiContext _context, AttendanceRepository _repository, AttendanceService _attendanceService, IMapper _mapper)
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
                return Ok(attendance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddAttendance([FromBody] PostAttendanceDTO postAttendanceDTO)
        {
            try
            {
                foreach (var data in postAttendanceDTO.Attendees)
                {
                    var attendance=_mapper.Map<Attendance>(data);
                    attendance.SessionId=postAttendanceDTO.SessionId;
                    await _repository.AddAttendance(attendance);
                }
                return CreatedAtAction(nameof(GetAttendance), new { }, postAttendanceDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateAttendance(AttendanceDTO newAttendance,int id)
        {
            if (newAttendance == null)
            {
                throw new ArgumentNullException(nameof(newAttendance));
            }
            Attendance UpdateAttendance = _mapper.Map<Attendance>(newAttendance);
            UpdateAttendance.Id = id;
            await _repository.UpdateAttendance(UpdateAttendance);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendanceById(int id)
        {
            try
            {
                var attendance = await _repository.GetAttendanceByIdAsync(id);
                if (attendance == null)
                {
                    return NotFound();
                }
                return Ok(attendance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]

        public async Task<ActionResult> DeleteAttendance(int id)
        {
            try
            {
                await _repository.DeleteAttendance(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
