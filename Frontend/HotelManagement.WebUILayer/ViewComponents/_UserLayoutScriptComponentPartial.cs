using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _UserLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
