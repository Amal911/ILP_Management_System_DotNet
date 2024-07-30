using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExposedBatchController:ControllerBase
    {
        
            private IExposedBatchRepository _repository;
            public ExposedBatchController(IExposedBatchRepository repository)
            {
                this._repository = repository;
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
