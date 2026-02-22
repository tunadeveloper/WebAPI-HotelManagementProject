using AutoMapper;
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

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetRole()
        {
            var list = await _roleManager.Roles.ToListAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> InsertRole(AppRole role)
        {
            var values = new AppRole()
            {
                Name = role.Name
            };

            var result = await _roleManager.CreateAsync(values);
            return Ok("Eklendi: " + result);
        }
    }
}
