using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository _sessionRepo;
        private readonly IMapper _mapper;

        public SessionController(ISessionRepository sessionRepo, IMapper mapper)
        {
            this._sessionRepo = sessionRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSessions()
        {
            var sessions = await _sessionRepo.GetAllAsync();
            var mappedSessions = _mapper.Map<IEnumerable<Session>>(sessions);

            var response = new APIResponse
            {
                Result = mappedSessions,
                StatusCode = HttpStatusCode.OK
            };

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<APIResponse>> GetSession(int id)
        {
            var session = await _sessionRepo.GetAsync(id);

            if (session == null)
            {
                return NotFound(new APIResponse { StatusCode = HttpStatusCode.NotFound });
            }

            var mappedSession = _mapper.Map<Session>(session);

            var response = new APIResponse
            {
                Result = mappedSession,
                StatusCode = HttpStatusCode.OK
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateBatch([FromBody] CreateSessionDTO createSessionDTO)
        {
            var newSession = _mapper.Map<Session>(createSessionDTO);
            await _sessionRepo.CreateAsync(newSession);
            await _sessionRepo.SaveAsync();
            var response = new APIResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.Created,
                Result = _mapper.Map<CreateSessionDTO>(newSession), 
                Message = { "Session created successfully" }
            };

            return Ok(response);
        }
    }
}
