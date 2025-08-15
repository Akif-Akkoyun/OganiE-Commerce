using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Configurations
{
    public class ProductImageEntityConfiguration : IEntityTypeConfiguration<ProductImageEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<App.Domain.Entities.ProductImageEntity> builder)
        {
            builder.HasKey(pi => pi.Id);
            builder.Property(pi => pi.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(pi => pi.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}