using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public void DeleteBL(SendMessage entity)
        {
            _sendMessageDal.Delete(entity);
        }

        public SendMessage GetByIdBL(int id)
        {
            return _sendMessageDal.GetById(id);
        }

        public List<SendMessage> GetListBL()
        {
            return _sendMessageDal.GetList();
        }

        public void InsertBL(SendMessage entity)
        {
            _sendMessageDal.Insert(entity);
        }

        public void UpdateBL(SendMessage entity)
        {
            _sendMessageDal.Update(entity);
        }
    }
}
