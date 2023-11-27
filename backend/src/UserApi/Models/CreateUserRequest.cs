using System.ComponentModel.DataAnnotations;

namespace UserApi.Models;

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
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [MinLength(8)]
    public string Password { get; set; } = null!;

    [RoleValidation]
    public string Role { get; set; } = "Member";
}
