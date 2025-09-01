using System;

namespace App.Domain.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }
        public byte StockAmount { get; set; }
        public bool Enabled { get; set; }

        // Navigation properties
        public CategoryEntity Category { get; set; } = null!;
        public UserEntity Seller { get; set; } = null!;
        public ICollection<ProductImageEntity> Images { get; set; } = new List<ProductImageEntity>();
        public ICollection<ProductCommentEntity> Comments { get; set; } = new List<ProductCommentEntity>();

    }
}
