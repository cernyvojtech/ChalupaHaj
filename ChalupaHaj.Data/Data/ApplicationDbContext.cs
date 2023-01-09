using ChalupaHaj.Data.Models;
using ChalupaHaj.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChalupaHaj.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Form> ContactUsForms { get; set; }

        public DbSet<ReservationForm> Reservation { get; set; }
        public DbSet<News> News { get; set; }
    }
}