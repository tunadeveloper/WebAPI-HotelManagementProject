using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.EntityLayer.Concrete
{
    public class Testimonial:BaseEntity
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
    }
}
