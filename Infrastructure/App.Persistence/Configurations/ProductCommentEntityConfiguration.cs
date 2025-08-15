using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations
{
    public class ProductCommentEntityConfiguration : IEntityTypeConfiguration<ProductCommentEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCommentEntity> builder)
        {
            builder.ToTable("ProductComments");
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Text)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(pc => pc.StarCount)
                .IsRequired();
            builder.Property(pc => pc.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Property(pc => pc.IsConfirmed)
                .IsRequired()
                .HasDefaultValue(false);
            // Relationships
            builder.HasOne(pc => pc.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(pc => pc.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(pc => pc.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
