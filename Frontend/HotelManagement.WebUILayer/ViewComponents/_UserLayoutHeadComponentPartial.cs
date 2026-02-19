using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _UserLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
