using AutoMapper;

using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;



namespace ILPManagementSystem.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class SessionAttendanceController:ControllerBase
    {
        private ApiContext _context;
        private SessionAttendanceRepository _sessionAttendanceRepository;
        private IMapper _mapper;

        public SessionAttendanceController(ApiContext _context, IMapper mapper, SessionAttendanceRepository _sessionAttendanceRepository)
        {
            this._sessionAttendanceRepository = _sessionAttendanceRepository;
            this._context = _context;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionAttendance>>>GetSessionAttendance()
        {
           var attendance = await _sessionAttendanceRepository.GetAllAttendancesAsync();
            return Ok(attendance);

        }
        [HttpPost]
        public IActionResult PostAttendance([FromBody] SessionAttendanceDTO sessionAttendance)
        {
            SessionAttendance newSessionAttendance = _mapper.Map<SessionAttendance>(sessionAttendance);
            _context.SessionAttendances.Add(newSessionAttendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
