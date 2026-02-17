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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _dal;

        public TestimonialManager(ITestimonialDal dal)
        {
            _dal = dal;
        }

        public void DeleteBL(Testimonial entity)
        {
           _dal.Delete(entity);
        }

        public Testimonial GetByIdBL(int id)
        {
           return _dal.GetById(id);
        }

        public List<Testimonial> GetListBL()
        {
           return _dal.GetList();
        }

        public void InsertBL(Testimonial entity)
        {
           _dal.Insert(entity);
        }

        public void UpdateBL(Testimonial entity)
        {
            _dal.Update(entity);
        }
    }
}
