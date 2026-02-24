using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class HotelBookingKaggleDatasetManager : IHotelBookingKaggleDatasetService
    {
        private readonly IHotelBookingKaggleDatasetDal _hotelBookingKaggleDatasetDal;

        public HotelBookingKaggleDatasetManager(IHotelBookingKaggleDatasetDal hotelBookingKaggleDatasetDal)
        {
            _hotelBookingKaggleDatasetDal = hotelBookingKaggleDatasetDal;
        }

        public void DeleteBL(HotelBookingKaggleDataset entity)
        {
            _hotelBookingKaggleDatasetDal.Delete(entity);
        }

        public HotelBookingKaggleDataset GetByIdBL(int id)
        {
            return _hotelBookingKaggleDatasetDal.GetById(id);
        }

        public List<HotelBookingKaggleDataset> GetListBL()
        {
            return _hotelBookingKaggleDatasetDal.GetList();
        }

        public List<HotelBookingKaggleDataset> GetTopBL(int count)
        {
            return _hotelBookingKaggleDatasetDal.GetTop(count);
        }

        public void InsertBL(HotelBookingKaggleDataset entity)
        {
            _hotelBookingKaggleDatasetDal.Insert(entity);
        }

        public void UpdateBL(HotelBookingKaggleDataset entity)
        {
            _hotelBookingKaggleDatasetDal.Update(entity);
        }
    }
}
