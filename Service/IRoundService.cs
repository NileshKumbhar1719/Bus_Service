

using LoginData.DTOs;
using LoginData.Model;

namespace LoginData.Service
{
    public interface IRoundService
    {
        Task<IEnumerable<BusRound>> GetAllAsync();
        Task<BusRound> GetByIdAsync(int id);
        Task AddAsync(BusRound round);
        Task UpdateAsync(BusRound round);
        Task DeleteAsync(int id);
    }
}
