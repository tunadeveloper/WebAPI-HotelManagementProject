using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _servicesService.GetListBL();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertService(Service service)
        {
            _servicesService.InsertBL(service);
            return Ok("Eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteService(int serviceId)
        {
            var values = _servicesService.GetByIdBL(serviceId);
            _servicesService.DeleteBL(values);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _servicesService.UpdateBL(service);
            return Ok("Güncellendi");
        }

        [HttpGet("GetById")]
        public IActionResult GetService(int serviceId)
        {
            var values = _servicesService.GetByIdBL(serviceId);
            return Ok(values);
        }
    }
}
