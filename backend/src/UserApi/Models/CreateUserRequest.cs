// CreateUserRequest.cs
using System.ComponentModel.DataAnnotations;

namespace UserApi.Models
{
    /// <summary>
    /// Represents a request to create a new user.
    /// </summary>
    public class CreateUserRequest
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 100 characters.")]
        public string Password { get; set; } = null!;

        [RoleValidation]
        public string Role { get; set; } = "Member";
    }
}
