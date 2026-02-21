using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.WorkLocationDTOs;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;
        private readonly IMapper _mapper;

        public WorkLocationController(IWorkLocationService workLocationService, IMapper mapper)
        {
            _workLocationService = workLocationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult WorkLocationList()
        {
            var list = _workLocationService.GetListBL();
            var values = _mapper.Map<List<ResultWorkLocationDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertWorkLocation(InsertWorkLocationDTO dto)
        {
            var entity = _mapper.Map<WorkLocation>(dto);
            _workLocationService.InsertBL(entity);
            return Ok("Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWorkLocation(int id)
        {
            var entity = _workLocationService.GetByIdBL(id);
            _workLocationService.DeleteBL(entity);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateWorkLocation(UpdateWorkLocationDTO dto)
        {
            var entity = _mapper.Map<WorkLocation>(dto);
            _workLocationService.UpdateBL(entity);
            return Ok("Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkLocation(int id)
        {
            var entity = _workLocationService.GetByIdBL(id);
            var value = _mapper.Map<ResultWorkLocationDTO>(entity);
            return Ok(value);
        }
    }
}
