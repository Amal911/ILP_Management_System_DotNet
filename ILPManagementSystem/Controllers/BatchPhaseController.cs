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
        private ApiContext _context;
        private BatchPhaseRepository _batchphaseRepository;
        private IMapper _mapper;

        public BatchPhaseController(ApiContext _context, BatchPhaseRepository _batchphaseRepository, IMapper _mapper)
        {
            this._context = _context;
            this._batchphaseRepository = _batchphaseRepository;
            this._mapper = _mapper;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<BatchPhase>>> GetAllBatchPhasesAsync()
        {
            return Ok(await _batchphaseRepository.GetAllBatchPhasesAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddNewBatchPhase([FromBody] BatchPhaseDTO newBatchPhase)
        {
            BatchPhase batchPhase=_mapper.Map<BatchPhase>(newBatchPhase);
            await _batchphaseRepository.AddNewBatchPhase(batchPhase);
            return Ok();
        }


    }
}
