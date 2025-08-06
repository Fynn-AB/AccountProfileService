using System.ComponentModel.DataAnnotations;

namespace AccountProfileService.DTOs;

public class CreateUserDto
{
    [Required]
    public required string UserName { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Phone]
    public string? Phone { get; set; }
}
