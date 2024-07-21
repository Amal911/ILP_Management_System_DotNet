using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BatchTypeController : ControllerBase
    {
        private BatchTypeRepository _batchTypeRepository;
        private IMapper _mapper;

        public BatchTypeController(BatchTypeRepository _batchTypeRepository, IMapper _mapper)
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
            BatchType batchType = _mapper.Map<BatchType>(newbatchtype);
            return Ok(_batchTypeRepository.AddBatchType(batchType));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBatchType(int id)
        {
            return Ok(_batchTypeRepository.DeleteBatchType(id));
        }
    }
}
