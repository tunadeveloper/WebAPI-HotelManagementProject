using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.GetListBL();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertTestimonial(Testimonial testimonial)
        {
            _testimonialService.InsertBL(testimonial);
            return Ok("Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.GetByIdBL(id);
            _testimonialService.DeleteBL(values);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialService.UpdateBL(testimonial);
            return Ok("Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.GetByIdBL(id);
            return Ok(values);
        }
    }
}
