using HotelManagement.DataTransferObjectLayer.DTOs.BookingDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5191/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult InsertBooking() => View();

        [HttpPost]
        public async Task<IActionResult> InsertBooking(InsertBookingDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5191/api/Booking", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Booking", new { area = "Admin" });

            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5191/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Booking", new { area = "Admin" });
            return RedirectToAction("Index", "Booking", new { area = "Admin" });
        }

        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5191/api/Booking/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBookingDTO>(jsonData);
                return View(value);
            }
            return RedirectToAction("Index", "Booking", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5191/api/Booking", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Booking", new { area = "Admin" });

            return View();
        }
    }
}
