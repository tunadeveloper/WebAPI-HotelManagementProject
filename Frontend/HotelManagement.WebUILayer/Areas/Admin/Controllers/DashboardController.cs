using HotelManagement.DataTransferObjectLayer.DTOs.BookingDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.RoomDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.ServiceDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.SubscribeDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace HotelManagement.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string ApiBaseUrl = "http://localhost:5191/api";

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("apiClient");

            var roomTask = GetListAsync<ResultRoomDTO>(client, $"{ApiBaseUrl}/Room");
            var bookingTask = GetListAsync<ResultBookingDTO>(client, $"{ApiBaseUrl}/Booking");
            var userTask = GetListAsync<ResultUserDTO>(client, $"{ApiBaseUrl}/Account");
            var messageTask = GetListAsync<ResultMessageDTO>(client, $"{ApiBaseUrl}/Message");
            var serviceTask = GetListAsync<ResultServiceDTO>(client, $"{ApiBaseUrl}/Service");
            var subscribeTask = GetListAsync<ResultSubscribeDTO>(client, $"{ApiBaseUrl}/Subscribe");

            await Task.WhenAll(roomTask, bookingTask, userTask, messageTask, serviceTask, subscribeTask);

            var rooms = await roomTask;
            var bookings = await bookingTask;
            var users = await userTask;
            var messages = await messageTask;
            var services = await serviceTask;
            var subscribes = await subscribeTask;

            ViewBag.RoomCount = rooms.Count;
            ViewBag.BookingCount = bookings.Count;
            ViewBag.UserCount = users.Count;
            ViewBag.MessageCount = messages.Count;
            ViewBag.ServiceCount = services.Count;

            ViewBag.AverageRoomPrice = rooms.Count == 0 ? 0 : rooms.Average(x => x.Price);
            ViewBag.MinRoomPrice = rooms.Count == 0 ? 0 : rooms.Min(x => x.Price);
            ViewBag.MaxRoomPrice = rooms.Count == 0 ? 0 : rooms.Max(x => x.Price);

            ViewBag.PendingBookingCount = bookings.Count(x => (x.Status ?? "").Contains("bekle", StringComparison.OrdinalIgnoreCase));
            ViewBag.ApprovedBookingCount = bookings.Count(x => (x.Status ?? "").Contains("onay", StringComparison.OrdinalIgnoreCase));
            ViewBag.CanceledBookingCount = bookings.Count(x => (x.Status ?? "").Contains("iptal", StringComparison.OrdinalIgnoreCase));

            ViewBag.LastMessages = messages
                .OrderByDescending(x => x.CreatedAt)
                .Take(4)
                .ToList();

            ViewBag.LastSubscribers = subscribes
                .OrderByDescending(x => x.Id)
                .Take(7)
                .ToList();

            ViewBag.LastRooms = rooms
                .OrderByDescending(x => x.Id)
                .Take(4)
                .ToList();

            var today = DateTime.Today;
            var last7Days = Enumerable.Range(0, 7).Select(i => today.AddDays(-6 + i)).ToList();

            var messageCountByDate = messages
                .Select(m => m.CreatedAt.Kind == DateTimeKind.Utc ? m.CreatedAt.ToLocalTime().Date : m.CreatedAt.Date)
                .GroupBy(d => d)
                .ToDictionary(g => g.Key, g => g.Count());

            var messageCounts = last7Days
                .Select(day => messageCountByDate.TryGetValue(day, out var count) ? count : 0)
                .ToList();

            var messageCategories = last7Days
                .Select(day => day.ToString("dd MM ddd ", CultureInfo.GetCultureInfo("tr-TR")))
                .ToList();

            ViewBag.DashboardDataJson = JsonConvert.SerializeObject(new
            {
                messageCategories,
                messageCounts,
                bookingStatusLabels = new[] { "Beklemede", "Onaylı", "İptal" },
                bookingStatusCounts = new[]
                {
                    (int)ViewBag.PendingBookingCount,
                    (int)ViewBag.ApprovedBookingCount,
                    (int)ViewBag.CanceledBookingCount
                }
            });

            return View();
        }

        private static async Task<List<T>> GetListAsync<T>(HttpClient client, string url)
        {
            var responseMessage = await client.GetAsync(url);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
    }
}
