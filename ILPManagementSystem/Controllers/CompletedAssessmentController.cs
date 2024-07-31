using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompletedAssessmentController : ControllerBase
    {
        public CompletedAssessmentRepository _completedAssessmentRepository;
        public CompletedAssessmentController(CompletedAssessmentRepository _completedAssessmentRepository)
        {
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

