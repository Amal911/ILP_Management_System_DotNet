using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using ILPManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AssessmentController : ControllerBase
    {
        private readonly AssessmentService _assessmentService;
        private readonly AssessmentRepository _assessmentRepository;
        private readonly ApiContext _context;


        public AssessmentController(AssessmentService assessmentService, AssessmentRepository assessmentRepository, ApiContext context)
        {
            _assessmentService = assessmentService;
            _assessmentRepository = assessmentRepository;
            _context = context;
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
                Console.WriteLine(marks);
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

        [HttpGet("GetAssessmentsByBatchId/getByBatchId/{batchId}")]
        public async Task<ActionResult<IEnumerable<AssessmentViewModel>>> GetAssessmentsByBatchId(int batchId)
        {
            if (_context == null)
            {
                return Problem("Entity set 'YourDbContext.Assessments' is null.");
            }

            var assessments = await _context.Assessments
                .Where(a => a.BatchId == batchId)
                .Select(a => new AssessmentViewModel
                {
                    Id = a.Id,
                    BatchId = a.BatchId,
                    AssessmentTitle = a.AssessmentTitle,
                    Description = a.Description,
                    TotalScore = a.TotalScore,
                    IsSubmitable = a.IsSubmitable,
                    DueDateTime = a.DueDateTime,
                    CreatedDate = a.CreatedDate,
                    DocumentPath = a.DocumentPath,
                    DocumentName = a.DocumentName,
                    DocumentContentType = a.DocumentContentType,
                    TotalCountOfTrainees = _context.Trainees.Count(t => t.BatchId == batchId),
                    TotalSubmits = _context.CompletedAssessment.Count(ca => ca.AssessmentId == a.Id)
                })
                .ToListAsync();

            if (assessments == null || !assessments.Any())
            {
                return NotFound($"No assessments found for batch id {batchId}");
            }

            return assessments;
        }

    }

}
