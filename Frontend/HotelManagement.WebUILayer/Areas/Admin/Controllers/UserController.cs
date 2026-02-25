using HotelManagement.DataTransferObjectLayer.DTOs.AppRoleDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.UserDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.WorkLocationDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserDTO>>(jsonData);
            return View(values);
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
            var client = _httpClientFactory.CreateClient("apiClient");
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5191/api/Account", content);
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

        public async Task<IActionResult> UpdateUserRoles(int id)
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var userResponse = await client.GetAsync("http://localhost:5191/api/Account/" + id);
            var userJson = await userResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UpdateUserDTO>(userJson);

            var rolesResponse = await client.GetAsync("http://localhost:5191/api/Role");
            var rolesJson = await rolesResponse.Content.ReadAsStringAsync();
            var allRoles = JsonConvert.DeserializeObject<List<ResultAppRoleDTO>>(rolesJson);

            var userRolesResponse = await client.GetAsync("http://localhost:5191/api/Account/GetRolesByUser/" + id);
            var userRolesJson = await userRolesResponse.Content.ReadAsStringAsync();
            var userRoleNames = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            ViewBag.AllRoles = allRoles;
            ViewBag.UserRoleNames = userRoleNames;
            ViewBag.UserId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRoles(int userId, List<string> roleNames)
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var dto = new AssignRolesDTO { UserId = userId, RoleNames = roleNames };
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5191/api/Account/AssignRoles", content);
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
