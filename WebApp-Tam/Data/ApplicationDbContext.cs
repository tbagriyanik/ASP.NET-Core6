using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp_Tam.Models;

namespace WebApp_Tam.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApp_Tam.Models.Kategori> Kategori { get; set; }
        public DbSet<WebApp_Tam.Models.Urun> Urun { get; set; }
        public DbSet<WebApp_Tam.Models.Kampanya> Kampanya { get; set; }
        public DbSet<WebApp_Tam.Models.Mesaj> Mesaj { get; set; }
    }
}