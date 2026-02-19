using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _HomeAboutSectionComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
