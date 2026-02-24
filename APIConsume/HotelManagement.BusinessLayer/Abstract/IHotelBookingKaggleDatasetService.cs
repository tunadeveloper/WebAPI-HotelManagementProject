using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Abstract
{
    public interface IHotelBookingKaggleDatasetService : IGenericService<HotelBookingKaggleDataset>
    {
        public List<HotelBookingKaggleDataset> GetTopBL(int count);
    }
}
