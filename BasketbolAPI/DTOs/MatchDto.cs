namespace BasketbolAPI.DTOs;

public class MatchDto
{
    public int Id { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public DateTime MatchDate { get; set; }
    public string HomeTeamName { get; set; } = string.Empty;
    public string AwayTeamName { get; set; } = string.Empty;
}
