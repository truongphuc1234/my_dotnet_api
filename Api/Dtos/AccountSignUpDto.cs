using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;
public class AccountSignUpDto
{
    [Required]
    [StringLength(24, MinimumLength = 6)]
    public string? UserName { get; set; }
    [Required]
    [StringLength(24, MinimumLength = 6)]
    public string? Password { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    [EmailAddressAttribute]
    public string? Email { get; set; }
}