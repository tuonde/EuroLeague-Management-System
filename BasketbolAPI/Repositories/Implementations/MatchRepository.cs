using BasketbolAPI.Data;
using BasketbolAPI.Models;
using BasketbolAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasketbolAPI.Repositories.Implementations;

public class MatchRepository : IMatchRepository
{
    private readonly AppDbContext _context;

    public MatchRepository(AppDbContext context)
    {
        _context = context;
    }

    private IQueryable<Match> MatchesWithTeams => _context.Matches
        .Include(m => m.HomeTeam)
        .Include(m => m.AwayTeam);

    public async Task<IEnumerable<Match>> GetAllAsync()
    {
        return await MatchesWithTeams.ToListAsync();
    }

    public async Task<Match?> GetByIdAsync(int id)
    {
        return await MatchesWithTeams.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Match>> GetMatchesByTeamIdAsync(int teamId)
    {
        return await MatchesWithTeams
            .Where(m => m.HomeTeamId == teamId || m.AwayTeamId == teamId)
            .ToListAsync();
    }

    public async Task<Match> AddAsync(Match match)
    {
        _context.Matches.Add(match);
        await _context.SaveChangesAsync();
        return await MatchesWithTeams.FirstAsync(m => m.Id == match.Id);
    }

    public async Task<bool> UpdateAsync(int id, Match match)
    {
        var existing = await _context.Matches.FirstOrDefaultAsync(m => m.Id == id);
        if (existing is null)
            return false;

        existing.HomeTeamId = match.HomeTeamId;
        existing.AwayTeamId = match.AwayTeamId;
        existing.HomeScore = match.HomeScore;
        existing.AwayScore = match.AwayScore;
        existing.MatchDate = match.MatchDate;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var match = await _context.Matches.FirstOrDefaultAsync(m => m.Id == id);
        if (match is null)
            return false;

        _context.Matches.Remove(match);
        await _context.SaveChangesAsync();
        return true;
    }
}
