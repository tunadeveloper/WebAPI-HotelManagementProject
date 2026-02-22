using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.DataAccessLayer.Concrete;
using HotelManagement.DataAccessLayer.Repositories;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {
        }

        public List<AppUser> UserListWithWorkLocation()
        {
            Context context = new Context();
            return context.Users
                .Include(x => x.WorkLocation)
                .ToList();
        }
    }
}
