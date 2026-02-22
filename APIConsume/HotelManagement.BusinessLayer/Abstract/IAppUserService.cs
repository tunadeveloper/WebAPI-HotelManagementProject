using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        List<AppUser> UserListWithWorkLocationBL();
    }
}
