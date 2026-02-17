using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.DataAccessLayer.Concrete;
using HotelManagement.DataAccessLayer.Repositories;
using HotelManagement.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DataAccessLayer.EntityFramework
{
    public class EfTestimonialService : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonialService(Context context) : base(context)
        {
        }
    }
}
