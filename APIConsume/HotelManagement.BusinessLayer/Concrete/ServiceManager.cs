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
    public class ServiceManager : IServicesService
    {
        private readonly IServiceDal _dal;

        public ServiceManager(IServiceDal dal)
        {
            _dal = dal;
        }

        public void DeleteBL(Service entity)
        {
            _dal.Delete(entity);
        }

        public Service GetByIdBL(int id)
        {
            return _dal.GetById(id);
        }

        public List<Service> GetListBL()
        {
            return _dal.GetList ();
        }

        public void InsertBL(Service entity)
        {
            _dal.Insert(entity);
        }

        public void UpdateBL(Service entity)
        {
            _dal.Update(entity);
        }
    }
}
