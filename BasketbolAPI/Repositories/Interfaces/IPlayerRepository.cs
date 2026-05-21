using BasketbolAPI.Models;

namespace BasketbolAPI.Repositories.Interfaces;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetAllAsync();
    Task<Player?> GetByIdAsync(int id);
    Task<IEnumerable<Player>> GetPlayersByTeamIdAsync(int teamId);
    Task<Player> AddAsync(Player player);
    Task<bool> UpdateAsync(int id, Player player);
    Task<bool> DeleteAsync(int id);
}
