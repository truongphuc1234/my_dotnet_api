using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper.Configuration.Annotations;

namespace Api.Entities;

public class UserProfile
{
    public int Id { get; set; }
    public string? Address { get; set; } = string.Empty;
    [NotMapped]
    public Image? Avatar { get; set; }
    [NotMapped]
    public Image? BackGround { get; set; }
    public bool? MarriageStatus { get; set; }
    public int UserId { get; set; }
    public AppUser? User { get; set; }
    public IList<Image>? Images { get; set; }
}
