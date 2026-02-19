using HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateNewUserDTO createNewUserDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new AppUser()
            {
                Name = createNewUserDTO.Name,
                Surname = createNewUserDTO.Surname,
                Email = createNewUserDTO.Email,
                UserName = createNewUserDTO.Username
            };

            var result = await _userManager.CreateAsync(appUser, createNewUserDTO.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors.Select(x=>x.Description));

            return Ok("Kayıt Başarılı");
        }
    }
}
