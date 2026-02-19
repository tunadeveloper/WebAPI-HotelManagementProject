using AutoMapper;
using HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.RoomDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.ServiceDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.SubscribeDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.TestimonialDTOs;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.WebAPILayer.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<InsertRoomDTO, Room>().ReverseMap();
            CreateMap<UpdateRoomDTO, Room>().ReverseMap();
            CreateMap<ResultRoomDTO, Room>().ReverseMap();

            CreateMap<InsertTestimonialDTO, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDTO, Testimonial>().ReverseMap();
            CreateMap<ResultTestimonialDTO, Testimonial>().ReverseMap();

            CreateMap<InsertServiceDTO, Service>().ReverseMap();
            CreateMap<UpdateServiceDTO, Service>().ReverseMap();
            CreateMap<ResultServiceDTO, Service>().ReverseMap();

            CreateMap<InsertSubscribeDTO, Subscribe>().ReverseMap();
            CreateMap<UpdateSubscribeDTO, Subscribe>().ReverseMap();
            CreateMap<ResultSubscribeDTO, Subscribe>().ReverseMap();

            CreateMap<CreateNewUserDTO, AppUser>().ReverseMap();
        }
    }
}
