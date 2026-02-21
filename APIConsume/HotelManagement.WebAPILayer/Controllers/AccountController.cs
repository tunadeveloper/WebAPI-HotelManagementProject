using AutoMapper;
using HotelManagement.DataTransferObjectLayer.DTOs.LoginDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.TokenDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.UserDTO;
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
        private readonly IMapper _mapper;
        private readonly IConfiguration _configration;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configration, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configration = configration;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var list = _userManager.Users.ToList();
            var values = _mapper.Map<List<ResultUserDTO>>(list);
            return Ok(values);
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
            var user = await _userManager.FindByNameAsync(loginUserDTO.Username);
            if (user == null)
                return BadRequest("Kullanıcı adı veya şifre hatalı.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDTO.Password, false);
            if (!result.Succeeded)
                return BadRequest("Kullanıcı adı veya şifre hatalı.");

            var token = TokenGenerator.GeneratorToken(user, _configration);

            return Ok(new TokenResponseDTO { Token = token });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var entity = _userManager.Users.FirstOrDefault(x=>x.Id == id);
            await _userManager.DeleteAsync(entity);
            return Ok("Silindi");
        }
    }
}
