using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void DeleteBL(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About GetByIdBL(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> GetListBL()
        {
            return _aboutDal.GetList();
        }

        public void InsertBL(About entity)
        {
            _aboutDal.Insert(entity);
        }

        public void UpdateBL(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
