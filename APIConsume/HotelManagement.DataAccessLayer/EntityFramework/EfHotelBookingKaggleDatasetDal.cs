using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.DataAccessLayer.Concrete;
using HotelManagement.DataAccessLayer.Repositories;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.DataAccessLayer.EntityFramework
{
    public class EfHotelBookingKaggleDatasetDal : GenericRepository<HotelBookingKaggleDataset>, IHotelBookingKaggleDatasetDal
    {
        public EfHotelBookingKaggleDatasetDal(Context context) : base(context)
        {
        }

        public List<HotelBookingKaggleDataset> GetTop(int count)
        {
            var context = new Context();
            var values = context.hotelBookingKaggleDatasets.Take(count).ToList();
            return values;
        }
    }
}
