using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using ILPManagementSystem.Services;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AssessmentController : ControllerBase
    {
        private readonly AssessmentService _assessmentService;
        private readonly AssessmentRepository _assessmentRepository;

        public AssessmentController(AssessmentService assessmentService, AssessmentRepository assessmentRepository)
        {
            _assessmentService = assessmentService;
            _assessmentRepository = assessmentRepository;
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<Assessment>>> GetAllAssessment()
        {
            return Ok(await _assessmentRepository.GetAssessments());
        }

        [HttpPost]
        public async Task<ActionResult> CreateAssessment([FromForm] CreateAssessmentDTO newAssessment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assessment = await _assessmentService.CreateAssessment(newAssessment);

            if (!newAssessment.IsSubmitable)
            {
                var marks = ParseMarks(Request.Form["marks"].FirstOrDefault());
                if (marks == null)
                {
                    return BadRequest("Marks data is missing or invalid");
                }

                await _assessmentService.SubmitMarks(assessment.Id, marks);
            }
            return Ok(assessment);
        }

        private List<CompletedAssessmentDTO> ParseMarks(string marksJson)
        {
            if (string.IsNullOrEmpty(marksJson))
            {
                return null;
            }

            try
            {
                var marks = JsonSerializer.Deserialize<List<CompletedAssessmentDTO>>(marksJson);
                return marks.Any() ? marks : null;
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }

}
