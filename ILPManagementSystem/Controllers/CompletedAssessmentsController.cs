using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompletedAssessmentsController:ControllerBase
    {
        private ApiContext _context;
        private IMapper _mapper;
        private CompletedAssessmentRepository _completedAssessmentRepository;
        public CompletedAssessmentsController(ApiContext _context,IMapper mapper,CompletedAssessmentRepository _completedAssessmentRepository)
        {
            this._context = _context;
            this._mapper = mapper;
            this._completedAssessmentRepository = _completedAssessmentRepository;
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<CompletedAssessment>>> GetAllCompletedAssessments()
        {
            return Ok(await _completedAssessmentRepository.GetCompletedAssessments());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CompletedAssessment>> GetCompletedAssessmentsById(int id)
        {
            var completedAssessments = await _completedAssessmentRepository.GetCompletedAssessmentsById(id);
            if (completedAssessments == null)
            {
                return BadRequest("Id Not Found");
            }
            return Ok(completedAssessments);
        }
        }

    }

