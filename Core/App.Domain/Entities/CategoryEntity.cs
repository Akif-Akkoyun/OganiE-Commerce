using System;
using System.Collections.Generic;
namespace App.Domain.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        //nav properties
        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
