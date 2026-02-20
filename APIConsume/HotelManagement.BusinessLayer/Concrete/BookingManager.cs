using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void DeleteBL(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking GetByIdBL(int id)
        {
            return _bookingDal.GetById(id);
        }

        public List<Booking> GetListBL()
        {
            return _bookingDal.GetList();
        }

        public void InsertBL(Booking entity)
        {
            _bookingDal.Insert(entity);
        }

        public void UpdateBL(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
