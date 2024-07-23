using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ILPManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userDtos = users.Select(user => new UserDTO
            {
                /*Id = user.Id,*/
                EmailId = user.EmailId,
                RoleId = user.RoleId,
                MobileNumber = user.MobileNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
            }).ToList();

            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UserDTO
            {
               /* Id = user.Id,*/
                EmailId = user.EmailId,
                RoleId = user.RoleId,
                MobileNumber = user.MobileNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
            };
            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);

            await _userRepository.AddUserAsync(user);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        {
            /*if (id != userDTO.Id)
            {
                return BadRequest();
            }*/

            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.EmailId = userDTO.EmailId;
            user.RoleId = userDTO.RoleId;
            user.MobileNumber = userDTO.MobileNumber;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Gender = userDTO.Gender;
            

            await _userRepository.UpdateUserAsync(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}