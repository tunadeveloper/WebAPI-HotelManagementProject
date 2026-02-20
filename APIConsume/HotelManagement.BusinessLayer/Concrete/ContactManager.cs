using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void DeleteBL(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact GetByIdBL(int id)
        {
            return _contactDal.GetById(id);
        }

        public List<Contact> GetListBL()
        {
            return _contactDal.GetList();
        }

        public void InsertBL(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public void UpdateBL(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
