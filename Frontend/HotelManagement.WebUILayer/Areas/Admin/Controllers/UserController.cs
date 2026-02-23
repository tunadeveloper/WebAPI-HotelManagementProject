using HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.UserDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.WorkLocationDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

        public async Task<IActionResult> InsertUser()
        {
            var workLocations = await GetWorkLocationsAsync();
            ViewBag.WorkLocations = workLocations;
            return View(new CreateNewUserDTO());
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(CreateNewUserDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.WorkLocations = await GetWorkLocationsAsync();
                return View(dto);
            }
            var client = _httpClientFactory.CreateClient("apiClient");
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore };
            var jsonData = JsonConvert.SerializeObject(dto, settings);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5191/api/Account", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                ViewBag.WorkLocations = await GetWorkLocationsAsync();
                TempData["InsertError"] = "Kayıt başarısız.";
                return View(dto);
            }
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var responseMessage = await client.DeleteAsync("http://localhost:5191/api/Account/" + id);
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }

        public async Task<IActionResult> UpdateUser(int id)
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var responseMessage = await client.GetAsync("http://localhost:5191/api/Account/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateUserDTO>(jsonData);

            values.WorkLocation ??= new ResultWorkLocationDTO();
            var workLocations = await GetWorkLocationsAsync();
            ViewBag.WorkLocations = workLocations;
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO dto)
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5191/api/Account", content);
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }

        private async Task<List<ResultWorkLocationDTO>> GetWorkLocationsAsync()
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var response = await client.GetAsync("http://localhost:5191/api/WorkLocation");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultWorkLocationDTO>>(jsonData);
        }
    }
}
