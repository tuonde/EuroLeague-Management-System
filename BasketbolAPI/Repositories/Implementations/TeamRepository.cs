using BasketbolAPI.Data;
using BasketbolAPI.Models;
using BasketbolAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasketbolAPI.Repositories.Implementations;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams.ToListAsync();
    }

    public async Task<Team?> GetByIdAsync(int id)
    {
        return await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Teams.AnyAsync(t => t.Name == name);
    }

    public async Task<Team> AddAsync(Team team)
    {
        _context.Teams.Add(team);
        await _context.SaveChangesAsync();
        return team;
    }

    public async Task<bool> UpdateAsync(int id, Team team)
    {
        var existing = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
        if (existing is null)
            return false;

        existing.Name = team.Name;
        existing.City = team.City;
        existing.Coach = team.Coach;
        existing.FoundedYear = team.FoundedYear;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
        if (team is null)
            return false;

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        return true;
    }
}
