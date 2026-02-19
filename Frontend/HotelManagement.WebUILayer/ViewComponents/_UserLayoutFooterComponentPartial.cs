using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _UserLayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
