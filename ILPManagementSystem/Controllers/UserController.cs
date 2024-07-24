using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

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
                RoleName = user.Role.RoleName,
                MobileNumber = user.MobileNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                IsActive = user.IsActive
            }).ToList();
         /*   var admins = userDtos.Where(u => u.RoleName == "Admin").ToList();
            var trainers = userDtos.Where(u => u.RoleName == "Trainer").ToList();*/
         return Ok(userDtos);

            /*return Ok(new { userDtos, admins, trainers });*/
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
                IsActive = user.IsActive
            };
            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO userDTO)
        {
            var user = new User
            {
                EmailId = userDTO.EmailId,
                Password = "defaultPassword",
                RoleId = userDTO.RoleId,
                MobileNumber = userDTO.MobileNumber,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Gender = userDTO.Gender,
                IsActive = userDTO.IsActive
            };

            await _userRepository.AddUserAsync(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, userDTO);
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
            user.IsActive = userDTO.IsActive;

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