using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class SubscribeManager : IGenericService<Subscribe>
    {
        private readonly ISubscribeDal _dal;

        public SubscribeManager(ISubscribeDal dal)
        {
            _dal = dal;
        }

        public void DeleteBL(Subscribe entity)
        {
           _dal.Delete(entity);
        }

        public Subscribe GetByIdBL(int id)
        {
            return _dal.GetById(id);
        }

        public List<Subscribe> GetListBL()
        {
            return _dal.GetList();
        }

        public void InsertBL(Subscribe entity)
        {
            _dal.Insert(entity);
        }

        public void UpdateBL(Subscribe entity)
        {
            _dal.Update(entity);
        }
    }
}
