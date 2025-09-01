using App.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u=> u.CreatedAt).HasConversion(
                v => v,
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.Property(u => u.RoleId).IsRequired();
            builder.Property(u => u.Enabled).IsRequired();
            builder.HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
