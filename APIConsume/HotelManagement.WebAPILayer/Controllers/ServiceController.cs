using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.ServiceDTOs;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        private readonly IMapper _mapper;

        public ServiceController(IServicesService servicesService, IMapper mapper)
        {
            _servicesService = servicesService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var list = _servicesService.GetListBL();
            var values = _mapper.Map<List<ResultServiceDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertService(InsertServiceDTO dto)
        {
            var entity = _mapper.Map<Service>(dto);
            _servicesService.InsertBL(entity);
            return Ok("Eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteService(int serviceId)
        {
            var entity = _servicesService.GetByIdBL(serviceId);
            _servicesService.DeleteBL(entity);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDTO dto)
        {
            var entity = _mapper.Map<Service>(dto);
            _servicesService.UpdateBL(entity);
            return Ok("Güncellendi");
        }

        [HttpGet("GetById")]
        public IActionResult GetService(int serviceId)
        {
            var entity = _servicesService.GetByIdBL(serviceId);
            var value = _mapper.Map<ResultServiceDTO>(entity);
            return Ok(value);
        }
    }
}
