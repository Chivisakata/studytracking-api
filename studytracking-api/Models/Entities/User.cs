using System.ComponentModel.DataAnnotations;

namespace studytracking_api.Models.Entities
{
    public class User
    {
        public Guid Id { get ; set; } = Guid.NewGuid();
        [Required]
        public required string Username { get; set; }
        public string Email { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public UserRole Role { get; set; } = UserRole.User;

    }

    public enum UserRole
    {
            Admin,
            User
    }
}
