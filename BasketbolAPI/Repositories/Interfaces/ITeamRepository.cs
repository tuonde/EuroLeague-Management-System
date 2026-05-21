using BasketbolAPI.Models;

namespace BasketbolAPI.Repositories.Interfaces;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllAsync();
    Task<Team?> GetByIdAsync(int id);
    Task<bool> ExistsByNameAsync(string name);
    Task<Team> AddAsync(Team team);
    Task<bool> UpdateAsync(int id, Team team);
    Task<bool> DeleteAsync(int id);
}
