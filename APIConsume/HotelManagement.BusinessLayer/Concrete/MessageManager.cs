using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void DeleteBL(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public Message GetByIdBL(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> GetListBL()
        {
            return _messageDal.GetList();
        }

        public void InsertBL(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void UpdateBL(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
