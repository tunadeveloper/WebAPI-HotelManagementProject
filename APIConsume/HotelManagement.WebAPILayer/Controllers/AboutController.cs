using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.AboutDTOs;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var list = _aboutService.GetListBL();
            var values = _mapper.Map<List<ResultAboutDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertAbout(InsertAboutDTO dto)
        {
            var entity = _mapper.Map<About>(dto);
            _aboutService.InsertBL(entity);
            return Ok("Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var entity = _aboutService.GetByIdBL(id);
            _aboutService.DeleteBL(entity);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO dto)
        {
            var entity = _mapper.Map<About>(dto);
            _aboutService.UpdateBL(entity);
            return Ok("Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var entity = _aboutService.GetByIdBL(id);
            return Ok(entity);
        }
    }
}
