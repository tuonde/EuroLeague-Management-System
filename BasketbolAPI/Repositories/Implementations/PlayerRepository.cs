using BasketbolAPI.Data;
using BasketbolAPI.Models;
using BasketbolAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasketbolAPI.Repositories.Implementations;

public class PlayerRepository : IPlayerRepository
{
    private readonly AppDbContext _context;

    public PlayerRepository(AppDbContext context)
    {
        _context = context;
    }

    private IQueryable<Player> PlayersWithTeam => _context.Players.Include(p => p.Team);

    public async Task<IEnumerable<Player>> GetAllAsync()
    {
        return await PlayersWithTeam.ToListAsync();
    }

    public async Task<Player?> GetByIdAsync(int id)
    {
        return await PlayersWithTeam.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Player>> GetPlayersByTeamIdAsync(int teamId)
    {
        return await PlayersWithTeam
            .Where(p => p.TeamId == teamId)
            .ToListAsync();
    }

    public async Task<Player> AddAsync(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return await PlayersWithTeam.FirstAsync(p => p.Id == player.Id);
    }

    public async Task<bool> UpdateAsync(int id, Player player)
    {
        var existing = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
        if (existing is null)
            return false;

        existing.FullName = player.FullName;
        existing.JerseyNumber = player.JerseyNumber;
        existing.Position = player.Position;
        existing.TeamId = player.TeamId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
        if (player is null)
            return false;

        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return true;
    }
}
