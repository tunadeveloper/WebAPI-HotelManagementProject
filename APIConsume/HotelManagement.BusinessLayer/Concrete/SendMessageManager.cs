using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;
        private readonly IEmailService _emailService;
        public SendMessageManager(ISendMessageDal sendMessageDal, IEmailService emailService)
        {
            _sendMessageDal = sendMessageDal;
            _emailService = emailService;
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
            _emailService.SendEmail(entity.ReceiverEmail, entity.Subject, entity.Content);
        }

        public void UpdateBL(SendMessage entity)
        {
            _sendMessageDal.Update(entity);
        }
    }
}
