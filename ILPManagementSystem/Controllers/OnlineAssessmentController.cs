using AutoMapper;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Validators;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FluentValidation;


namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OnlineAssessmentController:ControllerBase
    {
        private readonly OnlineAssessmentRepository _repository;
        private readonly IMapper _mapper;

        public OnlineAssessmentController(OnlineAssessmentRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOnlineAssessments()
        {
            try
            {
                var onlineAssessments = await _repository.GetAllAsync();
                if (onlineAssessments == null)
                {
                    var nullResponse = new APIResponse
                    {
                        IsSuccess = false,
                        Message = ["No users found."],
                        StatusCode = HttpStatusCode.NotFound
                    };

                    return NotFound(nullResponse);
                }

                var successResponse = new APIResponse
                {
                    IsSuccess = true,
                    Result = onlineAssessments,
                    StatusCode = HttpStatusCode.OK
                };

                return Ok(successResponse);
            }
            catch (Exception ex) 
            {
                var response = new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ["An internal error occurred while fetching online assessment."]
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            
        }

        [HttpGet("{id:batchId}")]
        public async Task<ActionResult<APIResponse>> GetOnlineAssessmentsByBatchId(int batchId)
        {
            try
            {
                var onlineAssessments = await _repository.GetAllAsync();
                var batchOnlineAssessments = onlineAssessments.Where(u => u.batchId == batchId).ToList();

                if (batchOnlineAssessments == null)
                {
                    var nullResponse = new APIResponse
                    {
                        IsSuccess = false,
                        Message = ["No Online Assessments found."],
                        StatusCode = HttpStatusCode.NotFound
                    };

                    return NotFound(nullResponse);
                }

                var response = new APIResponse
                {
                    IsSuccess = true,
                    Result = batchOnlineAssessments,
                    StatusCode = HttpStatusCode.OK
                };
                return Ok(response);
            }
            catch (Exception ex) 
            {
                var response = new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ["An internal error occurred while fetching online assessment."]
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateOnlineAssessment([FromBody] OnlineAssessment onlineAssessment)
        {
            try
            {
                if (onlineAssessment == null)
                {
                    var emptyResponse = new APIResponse
                    {
                        IsSuccess = false,
                        Message = ["Online assessment is null."],
                        StatusCode = HttpStatusCode.BadRequest
                    };

                    return BadRequest(emptyResponse);
                }
                var validator = new OnlineAssessmentValidator();
                var validationResult = await validator.ValidateAsync(onlineAssessment);

                if (!validationResult.IsValid)
                {
                    var badResponse = new APIResponse
                    {
                        IsSuccess = false,
                        Message = validationResult.Errors.Select(e => e.ErrorMessage).ToList(),
                        StatusCode = HttpStatusCode.BadRequest
                    };

                    return BadRequest(badResponse);
                }
                await _repository.CreateAsync(onlineAssessment);
                await _repository.SaveAsync();
                var response = new APIResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.Created,
                    Message = { "Session created successfully" }
                };

                return Ok(response);
            }
            catch (Exception ex) 
            {
                var response = new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ["An internal error occurred while fetching online assessment."]
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            
        }
    }
}
