using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.EntityLayer.Concrete
{
    public class WorkLocation : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
