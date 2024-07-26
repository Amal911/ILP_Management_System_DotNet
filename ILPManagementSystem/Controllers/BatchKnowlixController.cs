using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BatchKnowlixController:ControllerBase
    {
        private ApiContext _context;
        private IMapper _mapper;
        private BatchKnowlixRepository _batchKnowlixRepository;
        public BatchKnowlixController(ApiContext context, IMapper mapper, BatchKnowlixRepository batchKnowlixRepository)
        {
            this._batchKnowlixRepository = batchKnowlixRepository;
            this._context = context;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatchKnowlixDTO>>> GetAllBatches()
        {
            var batches = await _batchKnowlixRepository.GetAllAsync();
            var response = new APIResponse
            {
                IsSuccess = true,
                Result = batches,
                StatusCode = HttpStatusCode.OK
            };
            return Ok(response);
        }
    }
}
