using System.ComponentModel.DataAnnotations;

namespace AccountProfileService.DTOs;

public class UpdateUserDto
{
    [Required]
    public required string UserId { get; set; }
    [Required]
    public required string UserName { get; set; }

    [Required]
    [EmailAddress]    
    public required string Email { get; set; }

    [Required]
    [Phone]
    public string? PhoneNumber { get; set; }
}
