namespace BasketbolAPI.DTOs;

public class TeamDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Coach { get; set; } = string.Empty;
    public int FoundedYear { get; set; }
}
