using HotelManagement.DataTransferObjectLayer.DTOs.SubscribeDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5191/api/Subscribe");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSubscribeDTO>>(jsonData);
                return View(values);
            }
            return View(new List<ResultSubscribeDTO>());
        }

        public IActionResult InsertSubscribe() => View();

        [HttpPost]
        public async Task<IActionResult> InsertSubscribe(InsertSubscribeDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5191/api/Subscribe", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Subscribe", new { area = "Admin" });
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5191/api/Subscribe?subscribeId={id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Subscribe", new { area = "Admin" });
            return RedirectToAction("Index", "Subscribe", new { area = "Admin" });
        }

        public async Task<IActionResult> UpdateSubscribe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5191/api/Subscribe/GetById?subscribeId={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSubscribeDTO>(jsonData);
                return View(values);
            }
            return RedirectToAction("Index", "Subscribe", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscribe(UpdateSubscribeDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5191/api/Subscribe", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Subscribe", new { area = "Admin" });
            return View(dto);
        }
    }
}
