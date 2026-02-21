using HotelManagement.DataTransferObjectLayer.DTOs.LoginDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.TokenDTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateNewUserDTO createNewUserDTO)
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var jsonData = JsonConvert.SerializeObject(createNewUserDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5191/api/Account", content);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Login", "Account", new { area = "Admin" });

            return View(createNewUserDTO);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var jsonData = JsonConvert.SerializeObject(loginUserDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8 , "application/json");
            var response = await client.PostAsync("http://localhost:5191/api/Account/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var resultJson = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TokenResponseDTO>(resultJson);
                HttpContext.Session.SetString("AccessToken", values.Token);

                var identity = new ClaimsIdentity("CookieAuth");
                identity.AddClaim(new Claim(ClaimTypes.Name, loginUserDTO.Username));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("CookieAuth", principal, new AuthenticationProperties{ IsPersistent = false});

                return RedirectToAction("Index", "Room", new { area = "Admin" });
            }
            return View(loginUserDTO);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account", new { area = "Admin" });
        }
    }
}
