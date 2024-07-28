using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BatchPhaseController : ControllerBase
    {
        private BatchPhaseRepository _repository;
        private IMapper _mapper;

        public BatchPhaseController(BatchPhaseRepository _repository, IMapper _mapper)
        {
            this._repository = _repository;
            this._mapper = _mapper;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<BatchPhase>>> GetAllBatchPhasesAsync()
        {
            return Ok(await _repository.GetAllBatchPhasesAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddNewBatchPhase([FromBody] BatchPhaseDTO newBatchPhase)
        {
            BatchPhase batchPhase=_mapper.Map<BatchPhase>(newBatchPhase);
            await _repository.AddNewBatchPhase(batchPhase);
            return Ok();
        }


    }
}
