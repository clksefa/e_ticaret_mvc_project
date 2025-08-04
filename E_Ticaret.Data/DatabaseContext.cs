using E_Ticaret.Core.Entities;
using E_Ticaret.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace E_Ticaret.Data
{
    public class DatabaseContext : DbContext // internal kısmını public yaptık
    {
        // Burada nesnelerimizi oluşturduk.
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        // DatabaseContext üzerinden bu yapılandırmaları tanıtmamız gerekiyor EntityFramework'e
        // Önce konfigürasyon ayarını yapmamız lazım

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-74FDNEF; Database=EticaretDb; Trusted_Connection=True; TrustServerCertificate=True;");
            // Update Database PendingModelChangesWarning HATASI ALDIK
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)); // BU KOMUTU EKLEDİĞİMİZDE YUKARIYA
            // Bİ TANE USING EKLENİYOR.
            base.OnConfiguring(optionsBuilder); // Veritabanı bağlantı ayarı yaptığımız yer burası
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // bu metod uygulamamız çalıştığında
                                                                           // yapılandırmaları uygulamak için 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //çalışan dll'in içinden classları bulup çalıştıracak
            base.OnModelCreating(modelBuilder);
        }


    }
}
