using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace App.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.StockAmount)
                .IsRequired()
                .HasDefaultValue((byte)0);
            builder.Property(p => p.Enabled)
                .IsRequired()
                .HasDefaultValue(true);
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(p => p.Seller)
            //    .WithMany(u => u.Products)
            //    .HasForeignKey(p => p.SellerId)
            //    .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Images)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
