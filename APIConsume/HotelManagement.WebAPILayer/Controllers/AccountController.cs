using HotelManagement.DataTransferObjectLayer.DTOs.LoginDTO;
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
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(loginUserDTO.Username);
            if (user == null)
                return BadRequest("Kullanıcı adı veya şifre hatalı.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDTO.Password, false);
            if (!result.Succeeded)
                return BadRequest("Kullanıcı adı veya şifre hatalı.");

            return Ok("Giriş başarılı");
        }
    }
}
