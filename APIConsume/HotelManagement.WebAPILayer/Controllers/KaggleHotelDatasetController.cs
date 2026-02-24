using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.HotelBookingKaggleDatasetDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaggleHotelDatasetController : ControllerBase
    {
        private readonly IHotelBookingKaggleDatasetService _hotelBookingKaggleDatasetService;
        private readonly IMapper _mapper;
        public KaggleHotelDatasetController(IHotelBookingKaggleDatasetService hotelBookingKaggleDatasetService, IMapper mapper)
        {
            _hotelBookingKaggleDatasetService = hotelBookingKaggleDatasetService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStatistics()
        {
            var values = _hotelBookingKaggleDatasetService.GetTopBL(1000);
            var mapping = _mapper.Map<List<ResultHotelBookingDTO>>(values);
            return Ok(mapping);
        }
    }
}