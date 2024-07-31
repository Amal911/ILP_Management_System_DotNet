using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BatchPhaseController : ControllerBase
    {
        private IBatchPhaseRepository _repository;
        private IMapper _mapper;

        public BatchPhaseController(IBatchPhaseRepository _repository, IMapper _mapper)
        {
            this._repository = _repository;
            this._mapper = _mapper;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<BatchPhase>>> GetAllBatchPhasesAsync()
        {
            try
            {
                var batchPhases = await _repository.GetAllBatchPhasesAsync();
                var response = new APIResponse
                {
                    IsSuccess = true,
                    Result = batchPhases,
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
        public async Task<ActionResult> AddNewBatchPhase([FromBody] BatchPhaseDTO newBatchPhase)
        {
            try
            {
                BatchPhase batchPhase = _mapper.Map<BatchPhase>(newBatchPhase);
                await _repository.AddNewBatchPhase(batchPhase);
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.Created,
                    Result = batchPhase,
                    Message = new List<string> { "Batch Phase created successfully" }
                };
                return Ok(response);
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
        [HttpGet("{batchId}")]

        public async Task<ActionResult<IEnumerable<BatchPhase>>> GetBatchPhasesByBatchIdAsync(int batchId)
        {
            return Ok(await _repository.GetBatchPhasesByBatchIdAsync(batchId));
        }

    }
        

    }

