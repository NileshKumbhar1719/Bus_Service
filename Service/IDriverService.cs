using LoginData.DTOs;
using LoginData.Model;

namespace LoginData.Service
{
    public interface IDriverService
    {
        Task<Driver> CreateDriverAsync(DriverDTO dto);
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task<Driver> GetDriverByIdAsync(int id);
        Task UpdateDriverAsync(int id, DriverDTO dto);
        Task DeleteDriverAsync(int id);

    }
}
