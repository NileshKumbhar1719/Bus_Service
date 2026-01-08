using LoginData.DTOs;
using LoginData.Model;
using System.Linq.Expressions;

namespace LoginData.Service
{
    public interface IBusService
    {

        Task<IEnumerable<Bus>> GetAllBusesAsync();
        Task<Bus> GetBusByIdAsync(int id);
        Task<Bus> CreateBusAsync(BusDto dto);
        Task UpdateBusAsync(int id, BusDto dto);
        Task DeleteBusAsync(int id);

        Task<BusRound> CreateBusRoundAsync(BusRoundDto dto);
    }
}
