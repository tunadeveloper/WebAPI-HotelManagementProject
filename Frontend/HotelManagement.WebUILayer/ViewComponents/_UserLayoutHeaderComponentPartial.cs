using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _UserLayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
