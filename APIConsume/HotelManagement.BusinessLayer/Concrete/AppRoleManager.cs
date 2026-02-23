using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class AppRoleManager : IAppRoleService
    {
        private readonly IAppRoleDal _appRoleDal;

        public AppRoleManager(IAppRoleDal appRoleDal)
        {
            _appRoleDal = appRoleDal;
        }

        public void DeleteBL(AppRole entity)
        {
            _appRoleDal.Delete(entity);
        }

        public AppRole GetByIdBL(int id)
        {
            return _appRoleDal.GetById(id);
        }

        public List<AppRole> GetListBL()
        {
            return _appRoleDal.GetList();
        }

        public void InsertBL(AppRole entity)
        {
            _appRoleDal.Insert(entity);
        }

        public void UpdateBL(AppRole entity)
        {
            _appRoleDal.Update(entity);
        }
    }
}
