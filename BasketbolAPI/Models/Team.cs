using System.ComponentModel.DataAnnotations;

namespace BasketbolAPI.Models;

public class Team
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string City { get; set; } = string.Empty;

    public string Coach { get; set; } = string.Empty;
    public int FoundedYear { get; set; }
}
