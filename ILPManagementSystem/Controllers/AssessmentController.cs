using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class AssessmentController:ControllerBase
    {
        private ApiContext _context;
        private IMapper _mapper;
        private AssessmentRepository _assessmentRepository;

        public AssessmentController(ApiContext _context, IMapper _mapper, AssessmentRepository _assessmentRepository)
        {
            this._context = _context;
            this._mapper = _mapper; 
            this._assessmentRepository = _assessmentRepository; 
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assessment>>> GetAllAssessment()
        {
            return Ok(await _assessmentRepository.GetAssessments());
        }

        [HttpPost]
        public async Task<ActionResult> CreateAssessment([FromBody] CreateAssessmentDTO newAssessmet)
        {
            Assessment assessment = _mapper.Map<Assessment>(newAssessmet);
            await _assessmentRepository.CreateAssessment(assessment);
            return Ok();
        }
    }
}
