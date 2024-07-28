using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ApiContext _context;

        public RoleController(IRoleRepository roleRepository, ApiContext context)
        {
            _roleRepository = roleRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            var roleDtos = roles.Select(role => new RoleDTO
            {
                Id = role.Id,
                RoleName = role.RoleName
            }).ToList();

            return Ok(roleDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var roleDto = new RoleDTO
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
            return Ok(roleDto);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDTO>> CreateRole([FromBody] RoleDTO roleDto)
        {
            if (string.IsNullOrEmpty(roleDto.RoleName))
            {
                return BadRequest("RoleName is required.");
            }

            var role = new Role
            {
                RoleName = roleDto.RoleName
            };

            await _roleRepository.AddRoleAsync(role);
            await _context.SaveChangesAsync();

            roleDto.Id = role.Id;

            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, roleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleDTO roleDto)
        {
            if (id != roleDto.Id)
            {
                return BadRequest();
            }

            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(roleDto.RoleName))
            {
                return BadRequest("RoleName is required.");
            }

            role.RoleName = roleDto.RoleName;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            await _roleRepository.DeleteRoleAsync(id);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
