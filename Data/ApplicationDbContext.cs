using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelApp.Models;

namespace HotelApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HotelApp.Models.Rooms>? Rooms { get; set; }
        public DbSet<HotelApp.Models.Bookings>? Bookings { get; set; }
        public DbSet<HotelApp.Models.Checkout>? Checkout { get; set; }
    }
}