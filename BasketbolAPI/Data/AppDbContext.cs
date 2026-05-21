using BasketbolAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketbolAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Player> Players => Set<Player>();
    public DbSet<Match> Matches => Set<Match>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<Team>()
            .HasIndex(t => t.Name)
            .IsUnique();

        modelBuilder.Entity<Player>()
            .HasOne(p => p.Team)
            .WithMany()
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.HomeTeam)
            .WithMany()
            .HasForeignKey(m => m.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.AwayTeam)
            .WithMany()
            .HasForeignKey(m => m.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Team>().HasData(
            new Team { Id = 1, Name = "Galatasaray", City = "Istanbul", Coach = "Jurij Zdovc", FoundedYear = 1911 },
            new Team { Id = 2, Name = "Panathinaikos", City = "Athens", Coach = "Ergin Ataman", FoundedYear = 1919 },
            new Team { Id = 3, Name = "FC Barcelona", City = "Barcelona", Coach = "Roger Grimau", FoundedYear = 1923 },
            new Team { Id = 4, Name = "Real Madrid", City = "Madrid", Coach = "Chus Mateo", FoundedYear = 1931 },
            new Team { Id = 5, Name = "Fenerbahçe Beko", City = "Istanbul", Coach = "Sarunas Jasikevicius", FoundedYear = 1913 }
        );

        modelBuilder.Entity<Player>().HasData(
            new Player { Id = 1, FullName = "Sadık Emir Kabaca", JerseyNumber = 11, Position = "Forvet", TeamId = 1 },
            new Player { Id = 2, FullName = "David McCormack", JerseyNumber = 5, Position = "Pivot", TeamId = 1 },
            new Player { Id = 3, FullName = "James Palmer Jr.", JerseyNumber = 0, Position = "Şutör gard", TeamId = 1 },
            new Player { Id = 4, FullName = "Kostas Sloukas", JerseyNumber = 10, Position = "Oyun kurucu", TeamId = 2 },
            new Player { Id = 5, FullName = "Mathias Lessort", JerseyNumber = 26, Position = "Pivot", TeamId = 2 },
            new Player { Id = 6, FullName = "Juancho Hernangómez", JerseyNumber = 41, Position = "Forvet", TeamId = 2 },
            new Player { Id = 7, FullName = "Kostas Antetokounmpo", JerseyNumber = 37, Position = "Forvet", TeamId = 2 },
            new Player { Id = 8, FullName = "Nikola Kalinić", JerseyNumber = 12, Position = "Forvet", TeamId = 3 },
            new Player { Id = 9, FullName = "Sergio Llull", JerseyNumber = 23, Position = "Şutör gard", TeamId = 4 },
            new Player { Id = 10, FullName = "Nigel Hayes-Davis", JerseyNumber = 11, Position = "Forvet", TeamId = 5 },
            new Player { Id = 11, FullName = "Nick Calathes", JerseyNumber = 33, Position = "Oyun kurucu", TeamId = 5 },
            new Player { Id = 12, FullName = "Tyler Dorsey", JerseyNumber = 22, Position = "Şutör gard", TeamId = 5 }
        );

        modelBuilder.Entity<Match>().HasData(
            new Match { Id = 1, HomeTeamId = 1, AwayTeamId = 2, HomeScore = 78, AwayScore = 82, MatchDate = new DateTime(2024, 10, 17, 20, 45, 0, DateTimeKind.Utc) },
            new Match { Id = 2, HomeTeamId = 2, AwayTeamId = 1, HomeScore = 91, AwayScore = 76, MatchDate = new DateTime(2025, 1, 3, 19, 15, 0, DateTimeKind.Utc) },
            new Match { Id = 3, HomeTeamId = 1, AwayTeamId = 3, HomeScore = 71, AwayScore = 88, MatchDate = new DateTime(2024, 11, 8, 18, 30, 0, DateTimeKind.Utc) },
            new Match { Id = 4, HomeTeamId = 3, AwayTeamId = 4, HomeScore = 97, AwayScore = 83, MatchDate = new DateTime(2024, 12, 20, 20, 0, 0, DateTimeKind.Utc) },
            new Match { Id = 5, HomeTeamId = 2, AwayTeamId = 4, HomeScore = 86, AwayScore = 90, MatchDate = new DateTime(2025, 2, 6, 20, 30, 0, DateTimeKind.Utc) },
            new Match { Id = 6, HomeTeamId = 1, AwayTeamId = 5, HomeScore = 82, AwayScore = 79, MatchDate = new DateTime(2024, 12, 28, 19, 0, 0, DateTimeKind.Utc) }
        );
    }
}
