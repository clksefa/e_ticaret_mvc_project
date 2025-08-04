using E_Ticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace E_Ticaret.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            // Description kısmını yazmamıza gerek kalmadı ve zorunluda değil.
            builder.Property(x => x.Image).HasMaxLength(50);
            builder.HasData(new Category
            {
                Name = "Elektronik",
                Id = 1,
                IsActive = true,
                IsTopMenu = true,
                ParentID = 0,
                OrderNo = 1,
            }, new Category
            {
                Name = "Bilgisayar",
                Id = 2,
                IsActive = true,
                IsTopMenu = true,
                ParentID = 0,
                OrderNo = 2,
            }
            );
        }
    }
}
