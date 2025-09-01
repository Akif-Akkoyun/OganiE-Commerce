using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class ProductCommentEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; } = string.Empty;
        public byte StarCount{ get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsConfirmed { get; set; }
        //navigation properties
        public ProductEntity Product { get; set; } = null!;
        public UserEntity User { get; set; } = null!;
    }
}
