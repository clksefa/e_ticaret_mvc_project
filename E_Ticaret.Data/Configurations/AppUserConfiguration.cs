using E_Ticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
// DatabaseContext.cs'deki kısmı kopyaladık.
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Data.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Burada AppUser clasının veritabanında oluşacak olan tablosunun kolonlarının tiplerini ayarlicaz
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            // IsRequired => Yani bu alan zorunlu oldu
            // hasColumnType => Kolon tiplerini ayarlamak için
            // hasMaxLength => Maksimum karakter sayısı kadar olsun
            builder.Property(x => x.SurName).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Phone).HasColumnType("varchar(11)").HasMaxLength(11);
            // Telefon kısmı zorunlu olmadığı için IsRequired kullanmadık.
            builder.Property(x => x.Password).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);
            // daha fazla karakteri desteklesin dediğimiz için nvarchar yaptık.
            builder.Property(x => x.Username).HasColumnType("varchar(50)").HasMaxLength(50);

            // Bize bir tane başlangıç datası lazım
            // Yani başlangıçta kullanıcıya admin paneline giriş yapması gerekiyor.
            // Kullanıcıya e-mailin, kullanıcı adın, şifren budur gibisinden basit data veririz daha sonrasında kendisi değiştirebilir.

            builder.HasData(
                new AppUser { Id = 1, Username="Admin", Email="celiksefa6@gmail.com", IsActive=true,
                IsAdmin = true, Name="Sefa", SurName="Celik", Password="123456", });

        }
    }
}
