using AutoMapper;
using FluentValidation;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PhaseController:ControllerBase
    {
        private readonly PhaseService _phaseService;
        private PhaseRepository _phaseRepository;
        private IMapper _mapper;
        public PhaseController(ApiContext _context, PhaseRepository _phaseRepository, IMapper _mapper,PhaseService _phaseService)
        {
            this._phaseRepository = _phaseRepository;
            this._mapper = _mapper;
            this._phaseService = _phaseService;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phase>>> GetAllPhases()
        {
            try
            {
            var phases = await _phaseRepository.GetAllPhasesAsync();
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
                await _phaseRepository.AddNewPhase(phase);
                return CreatedAtAction(nameof(GetAllPhases), new { }, phase);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

    }
}
