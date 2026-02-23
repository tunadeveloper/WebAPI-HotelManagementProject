using HotelManagement.DataTransferObjectLayer.DTOs.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelManagement.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var responseMessage = await client.GetAsync("http://localhost:5191/api/Contact");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ResultContactDTO>>(jsonData);
            var lastItem = list?.LastOrDefault();
             return View(lastItem);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateContactDTO dto)
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5191/api/Contact", content);
            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        }
    }
}
