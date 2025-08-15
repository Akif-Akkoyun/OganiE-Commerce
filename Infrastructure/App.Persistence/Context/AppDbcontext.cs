using App.Domain.Entities;
using App.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Context
{
    internal class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductImageEntity> ProductImages { get; set; }
        public DbSet<ProductCommentEntity> ProductComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCommentEntityConfiguration());
        }
    }
}
