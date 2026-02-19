using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.DataAccessLayer.Concrete;
using HotelManagement.DataAccessLayer.Repositories;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(Context context) : base(context)
        {
        }
    }
}
