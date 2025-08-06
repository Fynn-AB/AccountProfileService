using System.ComponentModel.DataAnnotations;

namespace AccountProfileService.DTOs;

public class GetUserDto
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}
