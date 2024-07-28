using AutoMapper;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SessionController : ControllerBase
    {
        private readonly SessionRepository _sessionRepo;
        private readonly IMapper _mapper;

        public SessionController(SessionRepository sessionRepo, IMapper mapper)
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
                IsSuccess = true,
                Result = mappedSessions,
                StatusCode = HttpStatusCode.OK
            };

            return Ok(response);
        }

        [HttpGet("{batchId}")]
        public async Task<IActionResult> GetTodaysSessions(int batchId)
        {
            var today = DateTime.Today;
            try
            {
                var sessions = await _sessionRepo.GetAllAsync();
                var todaysSessions = sessions.Where(u => u.startTime.Date == today && u.batchId == batchId).ToList();
                var mappedSessions = _mapper.Map<IEnumerable<Session>>(todaysSessions);
                var response = new APIResponse
                {
                    IsSuccess = true,
                    Result = mappedSessions,
                    StatusCode = HttpStatusCode.OK
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new APIResponse
                {
                    IsSuccess = false,
                    Result = null,
                    StatusCode = HttpStatusCode.InternalServerError,
                });
            }
        
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
                IsSuccess= true,
                Result = mappedSession,
                StatusCode = HttpStatusCode.OK
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateSession([FromBody] CreateSessionDTO createSessionDTO)
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

        [HttpPut("{id}")]
        public async Task<IResult> UpdateSessionbyId(int id, [FromBody] CreateSessionDTO sessionDTO)
        {
            var existingSession = await _sessionRepo.GetAsync(id);
            if (existingSession == null)
            {
                return Results.NotFound(new APIResponse { StatusCode = HttpStatusCode.NotFound });
            }
            var sessionToUpdate = _mapper.Map(sessionDTO, existingSession);
            sessionToUpdate.Id = id;
            await _sessionRepo.UpdateAsync(sessionToUpdate);
            await _sessionRepo.SaveAsync();

            APIResponse response = new APIResponse
            {
                IsSuccess = true,
                Result = sessionToUpdate,
                StatusCode = HttpStatusCode.OK
            };
            return Results.Ok(response);
        }
    }
}
