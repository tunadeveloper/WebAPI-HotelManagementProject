using HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.UserDTO;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var responseMessage = await client.GetAsync("http://localhost:5191/api/Account");
            if (!responseMessage.IsSuccessStatusCode)
                return View(new List<ResultUserDTO>());
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserDTO>>(jsonData);
            return View(values ?? new List<ResultUserDTO>());
        }

        public IActionResult InsertUser() => View(new CreateNewUserDTO());

        [HttpPost]
        public async Task<IActionResult> InsertUser(CreateNewUserDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var client = _httpClientFactory.CreateClient("apiClient");
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5191/api/Account", content);
            if (!responseMessage.IsSuccessStatusCode)
                return View(dto);
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var responseMessage = await client.DeleteAsync("http://localhost:5191/api/Account/" + id);
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }
    }
}
