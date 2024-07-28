using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Services.ValidationServices;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhaseController:ControllerBase
    {
        private readonly PhaseService _phaseService;
        private PhaseRepository _repository;
        private IMapper _mapper;
        public PhaseController(ApiContext _context, PhaseRepository _repository, IMapper _mapper,PhaseService _phaseService)
        {
            this._repository = _repository;
            this._mapper = _mapper;
            this._phaseService = _phaseService;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phase>>> GetAllPhases()
        {
            try
            {
            var phases = await _repository.GetAllPhasesAsync();
            return Ok(phases);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }
        [HttpPost]

        public async Task<ActionResult> AddNewPhase([FromBody] PhaseDTO newPhase)
        {
            try
            {
                _phaseService.AddNewPhase(newPhase);
                Phase phase = _mapper.Map<Phase>(newPhase);
                await _repository.AddNewPhase(phase);
                return CreatedAtAction(nameof(GetAllPhases), new { }, phase);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletephase(int id)
        {
            return Ok(_repository.DeletePhase(id));
        }

        [HttpPut ("{id}")]

        public async Task<ActionResult> UpdatePhase(int id,PhaseDTO phase)
        {
            if (phase == null) 
            {
                throw new ArgumentNullException(nameof(phase));

            }
            Phase updatePhase = _mapper.Map<Phase>(phase);
            updatePhase.Id = id;
            await _repository.UpdatePhase(updatePhase);
            return Ok();
        }

    }
}
