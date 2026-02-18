using AutoMapper;
using HotelManagement.DataTransferObjectLayer.DTOs.RoomDTOs;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.WebAPILayer.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<InsertRoomDTO, Room>().ReverseMap();
            CreateMap<UpdateRoomDTO, Room>().ReverseMap();
        }
    }
}
