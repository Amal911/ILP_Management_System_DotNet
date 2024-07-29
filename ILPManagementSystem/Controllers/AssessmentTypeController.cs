using AutoMapper;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Services.ValidationServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[Action]")]

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
                var response = new APIResponse
                {
                    IsSuccess = true,
                    Result = assessmentTypes,
                    StatusCode = HttpStatusCode.OK
                };
                return Ok(assessmentTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = new List<string> { $"Internal server error: {ex.Message}" }
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNewAssessmentType([FromBody] AssessmentTypeDTO newAssessmentType)
        {
            try
            {
                _assessmentTypeService.ValidationAddNewAssessmentType(newAssessmentType);
                var assessmentType = _mapper.Map<AssessmentType>(newAssessmentType);
                await _assessmentTypeRepository.AddNewAssessmentType(assessmentType);
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.Created,
                    Result = assessmentType,
                    Message = new List<string> { "Assessment Type created successfully" }
                };
                return CreatedAtAction(nameof(GetAllAssessmentTypes), new { }, assessmentType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    IsSuccess = false,  
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = new List<string> { $"Internal server error: {ex.Message} - Inner Exception: {ex.InnerException?.Message}" }
                });
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAssessmentType(int id)
        {
            try
            {
                await _assessmentTypeRepository.DeleteAssessmentTypeById(id);
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.NoContent,
                    Message = new List<string> { "Assessment Type deleted successfully" }
                };
                return NoContent();
            }
            catch (Exception ex) {
                return StatusCode(500, new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = new List<string> { $"Internal server error: {ex.Message}" }
                });
            }
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateAssessmentType(int id, AssessmentTypeDTO assessmentType)
        {
            if (assessmentType is null)
            {
                return BadRequest(new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = new List<string> { "Invalid assessment type data" }
                });
            }
            try {
                AssessmentType updateAssessmentType = _mapper.Map<AssessmentType> (assessmentType);
                updateAssessmentType.Id = id;
                await _assessmentTypeRepository.UpdateAssessmentType(updateAssessmentType);
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = updateAssessmentType,
                    Message = new List<string> { "Assessment Type updated successfully" }
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = new List<string> { $"Internal server error: {ex.Message}" }
                });
            }

        }
    }
}
