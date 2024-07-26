using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OnlineAssessmentScoreController:ControllerBase
    {
        private ApiContext _context;
        private IMapper _mapper;
        private OnlineAssessmentScoreRepository _onlineAssessmentScoreRepository;
        public OnlineAssessmentScoreController(ApiContext context, IMapper mapper, OnlineAssessmentScoreRepository onlineAssessmentScoreRepository)
        {
            this._onlineAssessmentScoreRepository = onlineAssessmentScoreRepository;
            this._context = context;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnlineAssessmentScore>>> GetAllOnlineAssessmentScores()
        {
            var onlineAssessmentScores = await _onlineAssessmentScoreRepository.GetAllAsync();
            var response = new APIResponse
            {
                IsSuccess = true,
                Result = onlineAssessmentScores,
                StatusCode = HttpStatusCode.OK
            };
            return Ok(response);
        }
    }
}
