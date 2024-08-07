
using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BatchController : ControllerBase
    {
        private ApiContext _context;
        private IMapper _mapper;
        private BatchRepository _batchRepository;
        private CreateBatchService _batchService;

        public BatchController(ApiContext _context, IMapper mapper, BatchRepository _batchRepository, CreateBatchService _batchService)
        {
            this._batchRepository = _batchRepository;
            this._context = _context;
            this._mapper = mapper;
            this._batchService = _batchService;
        }
        /*        [HttpGet]
                  public IEnumerable<Batch> GetAllBatch2() { return _context.Batchs; }
        */

        /* [HttpGet]
         public IEnumerable<Batch>  GetAllBatch() {
             return  from b in _context.Batchs join bt in _context.BatchTypes on b.batchId equals bt.batchId select b;
         }*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetAllBatch()
        {
            return Ok(await _batchRepository.GetBatches());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatchDTO>>> GetAllBatchDetails()
        {
            return Ok(await _batchRepository.GetDetailedBatchData());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatchDTO>> GetBatchDetailById(int id)
        {
            var batch = await _batchRepository.GetBatchDetailById(id);
            if (batch.Count() == 0)
            {
                return BadRequest("Id not found");
            }
            return Ok(batch);
        }

        /*        [HttpPost]
                public async Task<ActionResult> CreateBatch(CreateBatchDTO batch)
                {
                    Batch newBatch = _mapper.Map<Batch>(batch);
                    await _batchRepository.AddNewBatch(newBatch);
                    return Ok();
                }*/

        [HttpPost]
        public async Task<ActionResult> CreateNewBatch(CreateNewBatchDTO batch)
        {
            await _batchService.CreateNewBatch(batch.BatchDetails, batch.PhaseDetails, batch.TraineeList);
            return Ok();
        }

        [HttpGet("{programId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetBatchByProgram(int programId)
        {
            IEnumerable<object> batchList = await _batchRepository.GetBatchByProgram(programId);
            return Ok(batchList);
        }

        [HttpGet("TraineeList/{Id}")]
        public async Task<ActionResult<object>> GetTraineeList(int Id)
        {
            var TraineeList = await _batchRepository.GetBatchTraineeList(Id);
            return Ok(TraineeList);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBatch(int id, [FromBody] UpdateBatchRequestDTO updateBatchRequest)
        {
            if (id != updateBatchRequest.Id)
            {
                return BadRequest("Batch ID mismatch");
            }

            try
            {
                await _batchRepository.UpdateBatchAsync(updateBatchRequest);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(new { message = "Batch details updated successfully!" });
        }



    }
}
