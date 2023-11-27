// AuthenticateRequest.cs
namespace UserApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a request to authenticate a user.
    /// </summary>
    public class AuthenticateRequest
    {
        /// <summary>
        /// The username of the user to authenticate.
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string Username { get; set; } = null!;

        /// <summary>
        /// The password of the user to authenticate.
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 100 characters.")]
        public string Password { get; set; } = null!;
    }
}
