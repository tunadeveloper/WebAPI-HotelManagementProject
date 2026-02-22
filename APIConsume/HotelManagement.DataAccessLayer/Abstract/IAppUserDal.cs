using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.DataAccessLayer.Abstract
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        List<AppUser> UserListWithWorkLocation();
    }
}
