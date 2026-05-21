namespace BasketbolAPI.DTOs;

public class PlayerUpdateDto
{
    public string FullName { get; set; } = string.Empty;
    public int JerseyNumber { get; set; }
    public string Position { get; set; } = string.Empty;
    public int TeamId { get; set; }
}
