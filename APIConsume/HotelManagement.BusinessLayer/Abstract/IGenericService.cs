using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void InsertBL(T entity);
        void UpdateBL(T entity);
        void DeleteBL(T entity);
        List<T> GetListBL();
        T GetByIdBL(int id);
    }
}
