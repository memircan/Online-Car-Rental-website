using AracKiralama.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AracKiralama.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Araba> Arabalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Kiralama> Kiralamalar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var kullanici = new Kullanici
            {
                Id = 1,
                KullaniciAdi = "admin",
                Sifre = "1234"
            };
            builder.Entity<Kullanici>().HasData(kullanici);
        }
    }
}
