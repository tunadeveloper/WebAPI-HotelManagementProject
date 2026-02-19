using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _RoomBookingSectionComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
