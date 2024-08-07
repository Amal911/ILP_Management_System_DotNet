using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using ILPManagementSystem.Models;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompletedAssessmentsController : ControllerBase
    {
            private readonly ICompletedAssessmentRepository _repository;
            private readonly IMapper _mapper;

            public CompletedAssessmentsController(ICompletedAssessmentRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<CompletedAssessmentDTO>> GetById(int id)
            {
                var completedAssessment = await _repository.GetByIdAsync(id);
                if (completedAssessment == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<CompletedAssessmentDTO>(completedAssessment));
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<CompletedAssessmentDTO>>> GetAll()
            {
                var completedAssessments = await _repository.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<CompletedAssessmentDTO>>(completedAssessments));
            }

            [HttpPost]
            public async Task<ActionResult<CompletedAssessmentDTO>> Create(CompletedAssessmentDTO completedAssessmentDTO)
            {
                var completedAssessment = _mapper.Map<CompletedAssessment>(completedAssessmentDTO);
                var createdAssessment = await _repository.AddAsync(completedAssessment);
                return CreatedAtAction(nameof(GetById), new { id = createdAssessment.Id }, _mapper.Map<CompletedAssessmentDTO>(createdAssessment));
            }
        }

    }

