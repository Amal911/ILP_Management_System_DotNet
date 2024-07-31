using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OnlineAssessmentController:ControllerBase
    {
        private ApiContext _context;
        private IMapper _mapper;
        private OnlineAssessmentRepository _onlineAssessmentRepository;
        public OnlineAssessmentController(ApiContext context, IMapper mapper, OnlineAssessmentRepository onlineAssessmentRepository)
        {
            this._onlineAssessmentRepository = onlineAssessmentRepository;
            this._context = context;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnlineAssessment>>> GetAllOnlineAssessmemts()
        {
            var onlineAssessments = await _onlineAssessmentRepository.GetAllAsync();
            var response = new APIResponse
            {
                IsSuccess = true,
                Result = onlineAssessments,
                StatusCode = HttpStatusCode.OK
            };
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateSession([FromBody] OnlineAssessment onlineAssessment)
        {
            await _onlineAssessmentRepository.CreateAsync(onlineAssessment);
            await _onlineAssessmentRepository.SaveAsync();
            var response = new APIResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.Created,
                Result = _mapper.Map<OnlineAssessment>(onlineAssessment),
                Message = { "Assessment created successfully" }
            };

            return Ok(response);
        }

    }
}
