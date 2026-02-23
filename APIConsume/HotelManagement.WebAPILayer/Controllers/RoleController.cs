using AutoMapper;
using HotelManagement.DataTransferObjectLayer.DTOs.AppRoleDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.UserDTO;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRole()
        {
            var list = await _roleManager.Roles.ToListAsync();
            var values = _mapper.Map<List<ResultAppRoleDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> InsertRole(InsertAppRoleDTO dto)
        {
            var result = _mapper.Map<AppRole>(dto);
            await _roleManager.CreateAsync(result);
            return Ok("Eklendi: " + result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateAppRoleDTO dto)
        {
            var result = _mapper.Map<AppRole>(dto);
            var existingRole = await _roleManager.Roles
        .FirstOrDefaultAsync(x => x.Id == result.Id);
            existingRole.Name = result.Name;
            await _roleManager.UpdateAsync(existingRole);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = await _roleManager.Roles.FirstOrDefaultAsync(x=>x.Id == id);
            await _roleManager.DeleteAsync(values);
            return Ok("Silindi");
        }

        [HttpGet("UsersByRole/{roleId}")]
        public async Task<IActionResult> GetUsersByRole(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            var users = await _userManager.GetUsersInRoleAsync(role.Name);
            var values = _mapper.Map<List<ResultUserDTO>>(users);
            return Ok(values);
        }
    }
}
