using E_Ticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Data.Configurations
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            // Description kısmını yazmamıza gerek kalmadı ve zorunluda değil.
            builder.Property(x => x.Logo).HasMaxLength(50);
        }
    }
}
