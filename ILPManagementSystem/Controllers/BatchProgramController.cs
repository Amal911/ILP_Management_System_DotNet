using AutoMapper;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BatchProgramController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BatchProgramRepository repository;

        public BatchProgramController(IMapper _mapper,BatchProgramRepository _repository)
        {
            this._mapper = _mapper;
            this.repository = _repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatchProgram>>> Get()
        {
            return Ok(await repository.GetBatchProgramsAsync());
        }
        [HttpGet("BatchList")]
        public async Task<ActionResult<IEnumerable<BatchProgram>>> GetBatchList()
        {
            return Ok(await repository.GetBatchProgramsWithBatchsAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<BatchProgram>> GetById(int Id)
        {
            return Ok(await repository.GetBatchProgramsAsync(Id));
        }

        [HttpGet("BatchCount/{Id}")]
        public async Task<ActionResult<int>> GetBatchCount(int  Id)
        {
            return Ok(await repository.GetBatchCount(Id));
        }
        
    }

}
