using studytracking_api.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace studytracking_api.Models.DataTransferObjects
{
    public class UpdateUserDto
    {
        public required string Username { get; set; }
        public string Email { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}
