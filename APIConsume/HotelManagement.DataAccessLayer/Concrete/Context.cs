using HotelManagement.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-97JKMRT\\SQLEXPRESS;Initial Catalog=HotelDb;Integrated Security=true;Encrypt=False;TrustServerCertificate=True");
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
    }
}
