using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Diagnostics;
using ILPManagementSystem.Repository;

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
            var users = await _userRepository.GetAllUsersAsync();
            
            var userDtos = users.Select(user => new 
            {
                Id = user.Id,
                EmailId = user.EmailId,
                RoleId = user.RoleId,
                RoleName = user.Role.RoleName,
                MobileNumber = user.MobileNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = (Gender)user.Gender,
            }).ToList();
            var admins = userDtos.Where(u => u.RoleName == "Admin").ToList();
            var trainers = userDtos.Where(u => u.RoleName == "Trainer").ToList();
            /*return Ok(userDtos);*/

            return Ok(new { userDtos, admins, trainers });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
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
            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody]UserDTO userDTO)
        {
            Console.WriteLine(userDTO);
            User user = this._mapper.Map<User>(userDTO);
            user.Gender= (Gender)userDTO.Gender;
            user.IsActive = true;
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
        [HttpGet("GetTrainers")]
        public async Task<ActionResult> GetTrainer()
        {
            return Ok(_userRepository.GetTrainers());
        } 
    }
}