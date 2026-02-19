using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _HomeBannerSectionComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
