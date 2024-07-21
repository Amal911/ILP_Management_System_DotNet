using AutoMapper;
using ILPManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompletedAssessmentController : ControllerBase
    {
        private ApiContext _context;
        private IMapper _mapper;
        public CompletedAssessmentRepository _completedAssessmentRepository;
        public CompletedAssessmentController(ApiContext _context,IMapper _mapper,CompletedAssessmentRepository _completedAssessmentRepository)
        {
            this._context = _context;
            this._mapper = _mapper;
            this._completedAssessmentRepository = _completedAssessmentRepository;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompletedAssessmentDTO>>> GetAllCompletedAssessments()
        {
            return Ok(await _completedAssessmentRepository.GetCompletedAssessment());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CompletedAssessmentDTO>> GetCompletedAssessmentById(int id)
        {
            var completedAssessments = await _completedAssessmentRepository.GetCompletedAssessmentById(id);
            if(completedAssessments == null) 
            {
                return BadRequest("Id Not Found");
            }
            return Ok(completedAssessments);
        }

    }
}

