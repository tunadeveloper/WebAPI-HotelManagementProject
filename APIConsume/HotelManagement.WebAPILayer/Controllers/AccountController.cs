using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.LoginDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.TokenDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.UserDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.WorkLocationDTOs;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configration;
        private readonly IEmailService _emailService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configration, IMapper mapper, IAppUserService appUserService, RoleManager<AppRole> roleManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configration = configration;
            _mapper = mapper;
            _appUserService = appUserService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var list = _appUserService.UserListWithWorkLocationBL();
            var values = _mapper.Map<List<ResultUserDTO>>(list);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = _appUserService.GetByIdBL(id);
            if (user == null)
                return NotFound();
            var value = _mapper.Map<UpdateUserDTO>(user);
            value.WorkLocation ??= new ResultWorkLocationDTO { Id = user.WorkLocationId };
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateNewUserDTO createNewUserDTO)
        {
            var user = _mapper.Map<AppUser>(createNewUserDTO);
            var createResult = await _userManager.CreateAsync(user, createNewUserDTO.Password);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var confirmationLink = $"{Request.Scheme}://{Request.Host}/api/Account/ConfirmEmail?userId={user.Id}&token={encodedToken}";
            await _emailService.SendEmailAsync(user.Email, "Email Doğrulama",
                $"<h3>Hesabınızı doğrulamak için aşağıdaki linke tıklayın:</h3>" +
                $"<a href='{confirmationLink}'>Emaili Doğrula</a>");

            return Ok("Kayıt başarılı. Lütfen emailinizi doğrulayın.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            var user = await _userManager.FindByNameAsync(loginUserDTO.Username);
            if (!await _userManager.IsEmailConfirmedAsync(user))
                return BadRequest("Email adresinizi doğrulamalısınız.");

            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, loginUserDTO.Password, false);
            var token = TokenGenerator.GeneratorToken(user, _configration);
            return Ok(new TokenResponseDTO { Token = token });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var entity = _userManager.Users.FirstOrDefault(x => x.Id == id);
            await _userManager.DeleteAsync(entity);
            return Ok("Silindi");
        }

        [HttpGet("GetRolesByUser/{userId}")]
        public async Task<IActionResult> GetRolesByUser(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        [HttpPost("AssignRoles")]
        public async Task<IActionResult> AssignRolesToUser(AssignRolesDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (dto.RoleNames != null && dto.RoleNames.Count > 0)
                await _userManager.AddToRolesAsync(user, dto.RoleNames);
            return Ok("Roller güncellendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.id.ToString());
            user.UserName = dto.userName;
            user.Email = dto.email;
            user.Name = dto.name;
            user.Surname = dto.surname;
            user.PhoneNumber = dto.phoneNumber?.ToString();
            user.WorkLocationId = dto.WorkLocation.Id;

            if (!string.IsNullOrEmpty(dto.password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, dto.password);
            }
            await _userManager.UpdateAsync(user);
            return Ok("Güncellendi");
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            if (result.Succeeded)
                return Ok("Email doğrulandı");

            return BadRequest("Email doğrulanamadı");
        }
    }
}
