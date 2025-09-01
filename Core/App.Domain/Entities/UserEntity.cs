namespace App.Domain.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public bool Enabled { get; set; }
        //navigation properties
        public RoleEntity? Role { get; set; }
        public ICollection<ProductCommentEntity> Comments { get; set; } = default!;
    }
}