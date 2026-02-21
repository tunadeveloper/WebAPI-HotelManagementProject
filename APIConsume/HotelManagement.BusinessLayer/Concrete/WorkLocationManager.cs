using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDal _workLocationDal;

        public WorkLocationManager(IWorkLocationDal workLocationDal)
        {
            _workLocationDal = workLocationDal;
        }

        public void DeleteBL(WorkLocation entity)
        {
            _workLocationDal.Delete(entity);
        }

        public WorkLocation GetByIdBL(int id)
        {
            return _workLocationDal.GetById(id);
        }

        public List<WorkLocation> GetListBL()
        {
            return _workLocationDal.GetList();
        }

        public void InsertBL(WorkLocation entity)
        {
            _workLocationDal.Insert(entity);
        }

        public void UpdateBL(WorkLocation entity)
        {
            _workLocationDal.Update(entity);
        }
    }
}
