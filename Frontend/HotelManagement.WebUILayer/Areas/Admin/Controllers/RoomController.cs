using HotelManagement.WebUILayer.Areas.Admin.Models.Room;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5191/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<RoomViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult InsertRoom() => View();

        [HttpPost]
        public async Task<IActionResult> InsertRoom(InsertRoomViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5191/api/Room", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Room", new {area="Admin"});
            }
            return View();
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5191/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Room", new { area = "Admin" });
            return RedirectToAction("Index", "Room", new { area = "Admin" });
        }

        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5191/api/Room/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateRoomViewModel>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UpdateRoomViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5191/api/Room", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Room", new { area = "Admin" });
            return View();
        }
    }
}
