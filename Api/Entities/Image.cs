namespace Api.Entities;

public class Image
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string PublicId { get; set; } = string.Empty;
    public int UserId { get; set; }
    public UserProfile? User { get; set; }
    public bool IsAvatar { get; set; }
    public bool IsBackGround { get; set; }
}