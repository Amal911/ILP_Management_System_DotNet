using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BatchTypeController : ControllerBase
    {
        private IBatchTypeRepository _batchTypeRepository;
        private IMapper _mapper;

        public BatchTypeController(IBatchTypeRepository _batchTypeRepository, IMapper _mapper)
        {
            this._batchTypeRepository = _batchTypeRepository;
            this._mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatchType>>> GetBatchTypes()
        {
            return Ok(await _batchTypeRepository.GetBatchTypeData());
        }

        [HttpPost]
        public async Task<ActionResult> AddNewBatchType([FromBody] BatchTypeDTO newbatchtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BatchType batchType = _mapper.Map<BatchType>(newbatchtype);
            await _batchTypeRepository.AddBatchType(batchType);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBatchType(int id)
        {
            await _batchTypeRepository.DeleteBatchType(id);
            return Ok();
        }
    }
}
