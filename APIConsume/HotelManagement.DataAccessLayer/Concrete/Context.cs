using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-97JKMRT\\SQLEXPRESS;Initial Catalog=HotelDb;Integrated Security=true;Encrypt=False;TrustServerCertificate=True");
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
        public DbSet<WorkLocation> WorkLocations { get; set; }
    }
}
