using System.ComponentModel.DataAnnotations;

namespace AccountProfileService.DTOs;

public class PasswordChangeDto
{
    [Required]
    public required string UserId { get; set; }
    [Required]
    public required string CurrentPassword { get; set; }
    [Required]
    public required string NewPassword { get; set; }
}
