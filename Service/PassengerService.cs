using LoginData.Data;
using LoginData.Model;
using LoginData.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LoginData.Service
{
    public class PassengerService : IPassengerService
    {
        private readonly IGenericRepository<Passenger> _pas;
        private readonly AppDbContext _AppDb;

        public PassengerService(IGenericRepository<Passenger>pas,AppDbContext AppDb) 
        {
            _pas=pas;
            _AppDb = AppDb;
        }
        public async Task<Passenger> CreateDATA(Passenger passenger)
        {
           
            var pas = new Passenger
            {
                Name = passenger.Name,
                
                Contact = passenger.Contact
            };
             await _pas.AddAsync(pas);
            await _pas.SaveAsync();
            return pas;

        }

        public  async Task DeleteDATA(int id)
        {
           var data = await _pas.GetByIdAsync(id);
            if (data == null)
                throw new KeyNotFoundException("Passenger not found.");
            _pas.Delete(data);
            await _pas.SaveAsync();
        }

        public  async Task<Passenger> GetDATAById(int id)
        {
            var data = await _pas.GetByIdAsync(id);
            if (data == null)
                throw new KeyNotFoundException("Passenger not found.");
            return data;
        }

        public  async Task<IEnumerable<Passenger>> GettAllDATA()
        {
           return await _pas.GetAllAsync();
        }

        public async Task UpdateDATA(int id, Passenger passenger)
        {
            var data = await _pas.GetByIdAsync(id);
            if (data == null)
                throw new KeyNotFoundException("Passenger not found.");
            data.Name = passenger.Name;
            data.Contact = passenger.Contact;
            _pas.Update(data);
            await _pas.SaveAsync();
            
        }
    }
}
