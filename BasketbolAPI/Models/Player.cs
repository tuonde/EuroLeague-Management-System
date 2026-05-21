using System.ComponentModel.DataAnnotations;

namespace BasketbolAPI.Models;

public class Player
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FullName { get; set; } = string.Empty;

    [Range(0, 99)]
    public int JerseyNumber { get; set; }

    public string Position { get; set; } = string.Empty;
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}
