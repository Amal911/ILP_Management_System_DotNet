
using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System.Reflection.Metadata.Ecma335;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BatchController: ControllerBase
    {
        private ApiContext _context;
        private IMapper _mapper;
        private BatchRepository _batchRepository;

        public BatchController(ApiContext _context, IMapper mapper, BatchRepository _batchRepository)
        {
            this._batchRepository = _batchRepository;
            this._context = _context;
            this._mapper = mapper;
        }
/*        [HttpGet]
          public IEnumerable<Batch> GetAllBatch2() { return _context.Batchs; }
*/

        /* [HttpGet]
         public IEnumerable<Batch>  GetAllBatch() {
             return  from b in _context.Batchs join bt in _context.BatchTypes on b.batchId equals bt.batchId select b;
         }*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetAllBatch() {
            return Ok(await _batchRepository.GetBatchData());
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
            if (batch.Count()==0) {
                return BadRequest("Id not found");
            }
            return Ok(batch);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBatch(CreateBatchDTO batch)
        {
            Batch newBatch = _mapper.Map<Batch>(batch);
            await _batchRepository.AddNewBatch(newBatch);
            return Ok();
        }
    }
}
