using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.DataAccessLayer.Concrete;
using HotelManagement.DataAccessLayer.Repositories;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.DataAccessLayer.EntityFramework
{
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonialDal(Context context) : base(context)
        {
        }
    }
}
