using BasketbolAPI.Models;

namespace BasketbolAPI.Repositories.Interfaces;

public interface IMatchRepository
{
    Task<IEnumerable<Match>> GetAllAsync();
    Task<Match?> GetByIdAsync(int id);
    Task<IEnumerable<Match>> GetMatchesByTeamIdAsync(int teamId);
    Task<Match> AddAsync(Match match);
    Task<bool> UpdateAsync(int id, Match match);
    Task<bool> DeleteAsync(int id);
}
