using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void DeleteBL(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public AppUser GetByIdBL(int id)
        {
            return _appUserDal.GetById(id);
        }

        public List<AppUser> GetListBL()
        {
            return _appUserDal.GetList();
        }

        public void InsertBL(AppUser entity)
        {
            _appUserDal.Insert(entity);
        }

        public void UpdateBL(AppUser entity)
        {
            _appUserDal.Update(entity);
        }

        public List<AppUser> UserListWithWorkLocationBL()
        {
            return _appUserDal.UserListWithWorkLocation();
        }
    }
}
