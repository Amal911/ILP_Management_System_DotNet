using AutoMapper;
using ILPManagementSystem.Data;
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
    public class PhaseController:ControllerBase
    {
        private readonly PhaseService _phaseService;
        private PhaseRepository _repository;
        private IMapper _mapper;
        public PhaseController(PhaseRepository _repository, IMapper _mapper,PhaseService _phaseService)
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
                var response = new APIResponse
                {
                    IsSuccess = true,
                    Result = phases,
                    StatusCode = HttpStatusCode.OK
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
        [HttpPost]

        public async Task<ActionResult> AddNewPhase([FromBody] PhaseDTO newPhase)
        {
            try
            {
                var validationResult = _phaseService.ValidateAddNewPhase(newPhase);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new APIResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                    });
                }
                Phase phase = _mapper.Map<Phase>(newPhase);
                await _repository.AddNewPhase(phase);
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.Created,
                    Result = phase,
                    Message = new List<string> { "Phase added successfully" }
                };
                return CreatedAtAction(nameof(GetAllPhases), new { }, phase);
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
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletephase(int id)
        {
            try
            {
                await _repository.DeletePhase(id);

                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.NoContent,
                    Message = new List<string> { "Phase deleted successfully" }
                };
                return NoContent();
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

        [HttpPut ("{id}")]

        public async Task<ActionResult> UpdatePhase(int id,PhaseDTO phase)
        {
            if (phase == null) 
            {
                return BadRequest(new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = new List<string> { "Invalid phase data" }
                });
            }
            try
            {
            Phase updatePhase = _mapper.Map<Phase>(phase);
            updatePhase.Id = id;
            await _repository.UpdatePhase(updatePhase);
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = updatePhase,
                    Message = new List<string> { "Phase updated successfully" }
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
