using LoginData.Model;
using System.Data.SqlTypes;

namespace LoginData.Service
{
    public interface IPassengerService
    {
        Task<IEnumerable<Passenger>> GettAllDATA();
        Task<Passenger> GetDATAById(int id);
        Task<Passenger> CreateDATA(Passenger passenger);
        Task UpdateDATA(int id, Passenger passenger);
        Task DeleteDATA(int id);
    }
}
