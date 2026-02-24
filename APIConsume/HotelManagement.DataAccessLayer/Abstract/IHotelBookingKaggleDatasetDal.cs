using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.DataAccessLayer.Abstract
{
    public interface IHotelBookingKaggleDatasetDal : IGenericDal<HotelBookingKaggleDataset>
    {
        public List<HotelBookingKaggleDataset> GetTop(int count);
    }
}
