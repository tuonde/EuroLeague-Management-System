using System.ComponentModel.DataAnnotations;

namespace BasketbolAPI.Models;

public class Match
{
    public int Id { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }

    [Range(0, 200)]
    public int HomeScore { get; set; }

    [Range(0, 200)]
    public int AwayScore { get; set; }

    public DateTime MatchDate { get; set; }
    public Team? HomeTeam { get; set; }
    public Team? AwayTeam { get; set; }
}
