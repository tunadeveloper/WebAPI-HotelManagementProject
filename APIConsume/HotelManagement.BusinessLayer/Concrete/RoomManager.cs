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
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void DeleteBL(Room entity)
        {
            _roomDal.Delete(entity);
        }

        public Room GetByIdBL(int id)
        {
            return _roomDal.GetById(id);
        }

        public List<Room> GetListBL()
        {
            return _roomDal.GetList();
        }

        public void InsertBL(Room entity)
        {
           _roomDal.Insert(entity);
        }

        public void UpdateBL(Room entity)
        {
            _roomDal.Update(entity);
        }
    }
}
