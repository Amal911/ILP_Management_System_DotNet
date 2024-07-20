using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using ILPManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AssessmentTypeController : ControllerBase
    {
        private readonly AssessmentTypeService _assessmentTypeService;
        private readonly AssessmentTypeRepository _assessmentTypeRepository;
        private readonly IMapper _mapper;

        public AssessmentTypeController(AssessmentTypeRepository assessmentTypeRepository, IMapper mapper, AssessmentTypeService assessmentTypeService)
        {
            _assessmentTypeRepository = assessmentTypeRepository;
            _mapper = mapper;
            _assessmentTypeService = assessmentTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssessmentType>>> GetAllAssessmentTypes()
        {
            try
            {
                var assessmentTypes = await _assessmentTypeRepository.GetAllAssessmentTypeAsync();
                return Ok(assessmentTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNewAssessmentType([FromBody] AssessmentTypeDTO newAssessmentType)
        {
            try
            {
                _assessmentTypeService.AddNewAssessmentType(newAssessmentType);
                var assessmentType = _mapper.Map<AssessmentType>(newAssessmentType);
                await _assessmentTypeRepository.AddNewAssessmentType(assessmentType);
                return CreatedAtAction(nameof(GetAllAssessmentTypes), new { }, assessmentType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message} - Inner Exception: {ex.InnerException?.Message}");
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAssessmentType(int id)
        {
            try
            {
                await _assessmentTypeRepository.DeleteAssessmentTypeById(id);
                return NoContent();
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
