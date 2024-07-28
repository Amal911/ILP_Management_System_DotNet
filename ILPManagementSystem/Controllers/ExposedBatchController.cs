using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExposedBatchController:ControllerBase
    {
        
            private ApiContext _context;
            private IMapper _mapper;
            private ExposedBatchRepository _repository;
            public ExposedBatchController(ApiContext context, IMapper mapper, ExposedBatchRepository repository)
            {
                this._repository = repository;
                this._context = context;
                this._mapper = mapper;
            }
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ExposedBatchDTO>>> GetAllBatches()
            {
                var batches = await _repository.GetAllAsync();
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
