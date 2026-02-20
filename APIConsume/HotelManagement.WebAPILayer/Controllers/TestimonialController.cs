using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.TestimonialDTOs;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var list = _testimonialService.GetListBL();
            var values = _mapper.Map<List<ResultTestimonialDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertTestimonial(InsertTestimonialDTO dto)
        {
            var entity = _mapper.Map<Testimonial>(dto);
            _testimonialService.InsertBL(entity);
            return Ok("Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var entity = _testimonialService.GetByIdBL(id);
            _testimonialService.DeleteBL(entity);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO dto)
        {
            var entity = _mapper.Map<Testimonial>(dto);
            _testimonialService.UpdateBL(entity);
            return Ok("Güncellendi");
        }

        [HttpGet("GetById")]
        public IActionResult GetTestimonial(int testimonialId)
        {
            var entity = _testimonialService.GetByIdBL(testimonialId);
            var value = _mapper.Map<ResultTestimonialDTO>(entity);
            return Ok(value);
        }
    }
}
