using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;
public class AccountSignUpDto
{
    [Required]
    [StringLength(24, MinimumLength = 6)]
    public string UserName { get; set; } = string.Empty;
    [Required]
    [StringLength(24, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    [EmailAddressAttribute]
    public string Email { get; set; } = string.Empty;
}