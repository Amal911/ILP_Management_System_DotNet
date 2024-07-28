using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Diagnostics;
using ILPManagementSystem.Repository;
using System.Net;

namespace ILPManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(UserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();

                if (users == null)
                {
                    var response = new APIResponse
                    {
                        IsSuccess = false,
                        Message = ["No users found."],
                        StatusCode = HttpStatusCode.NotFound
                    };

                    return NotFound(response);
                }

                var userDtos = users.Select(user => new
                {
                    /*                Id = user.Id,
                    */
                    EmailId = user.EmailId,
                    RoleId = user.RoleId,
                    MobileNumber = user.MobileNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = (Gender)user.Gender,
                    RoleName = user.Role.RoleName,
                }).ToList();

                var successResponse = new APIResponse
                {
                    IsSuccess = true,
                    Result = userDtos,
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
                    Message = ["An internal error occurred while fetching users."]
                };
                
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    var response = new APIResponse
                    {
                        IsSuccess = false,
                        Message=["User not found."],
                        StatusCode = HttpStatusCode.NotFound
                    };
                    
                    return NotFound(response);
                }

                var userDTO = new
                {
                    /* Id = user.Id,*/
                    EmailId = user.EmailId,
                    RoleId = user.RoleId,
                    MobileNumber = user.MobileNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    RoleName = user.Role.RoleName
                };

                var successResponse = new APIResponse
                {
                    IsSuccess = true,
                    Result = userDTO,
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
                    Message = ["An internal error occurred while fetching user."]
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }

        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody]UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                {
                    var emptyResponse = new APIResponse
                    {
                        IsSuccess = false,
                        Message=["User data is null."],
                        StatusCode = HttpStatusCode.BadRequest
                    };
                    
                    return BadRequest(emptyResponse);
                }
                var validator = new UserDTOValidator(); 
                var validationResult = await validator.ValidateAsync(userDTO);

                if (!validationResult.IsValid)
                {
                    var badResponse = new APIResponse
                    {
                        IsSuccess = false,
                        Message=validationResult.Errors.Select(e => e.ErrorMessage).ToList(),
                        StatusCode = HttpStatusCode.BadRequest
                    };
                    
                    return BadRequest(badResponse);
                }

                Console.WriteLine(userDTO);
                User user = this._mapper.Map<User>(userDTO);
                user.Gender = (Gender)userDTO.Gender;
                user.IsActive = true;
                await _userRepository.AddUserAsync(user);

                var successResponse = new APIResponse
                {
                    IsSuccess = true,
                    Result = userDTO,
                    StatusCode = HttpStatusCode.Created
                };
                
                return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, successResponse);
            }
            catch (Exception ex) 
            {
                var response = new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ["An internal error occurred while creating the user."]
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        {
            /*if (id != userDTO.Id)
            {
                return BadRequest();
            }*/
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    var notFoundResponse = new APIResponse
                    {
                        IsSuccess = false,
                        Message = ["User not found."],
                        StatusCode = HttpStatusCode.NotFound
                    };

                    return NotFound(notFoundResponse);
                }

                var validator = new UserDTOValidator(); 
                var validationResult = await validator.ValidateAsync(userDTO);

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

                user.EmailId = userDTO.EmailId;
                user.RoleId = userDTO.RoleId;
                user.MobileNumber = userDTO.MobileNumber;
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.Gender = userDTO.Gender;

                await _userRepository.UpdateUserAsync(user);

                var successResponse = new APIResponse
                {
                    IsSuccess = true,
                    Message = ["User data updated successfully"],
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
                    Message = ["An internal error occurred while updating the user details."]
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await _userRepository.DeleteUserAsync(id);
                if (!result)
                {
                    var notFoundResponse = new APIResponse
                    {
                        IsSuccess = false,
                        Message = ["User not found."],
                        StatusCode = HttpStatusCode.NotFound
                    };

                    return NotFound(notFoundResponse);
                }

                var successResponse = new APIResponse
                {
                    IsSuccess = true,
                    Message = [$"User {id} deleted successfully"],
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
                    Message = ["An internal error occurred while deleting the user."]
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }


        }

        [HttpGet("GetTrainers")]
        public async Task<ActionResult> GetTrainer()
        {
            return Ok(_userRepository.GetTrainers());
            /*try
            {
                var trainers = _userRepository.GetTrainers();
                if (trainers == null)
                {
                    var response = new APIResponse
                    {
                        IsSuccess = false,
                        Message = ["No trainers found."],
                        StatusCode = HttpStatusCode.NotFound
                    };

                    return NotFound(response);
                }

                var successResponse = new APIResponse
                {
                    IsSuccess = true,
                    Result = trainers,
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
                    Message = ["An internal error occurred while fetching trainers."]
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }*/

        } 
    }
}