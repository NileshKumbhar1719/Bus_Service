using LoginData.Data;
using LoginData.DTOs;
using LoginData.Model;
using LoginData.Repository;

namespace LoginData.Service
{
    public class DriverService : IDriverService
    {
        private readonly IGenericRepository<Driver> _Gen;
        private readonly AppDbContext _AppDb;

        public DriverService(IGenericRepository<Driver> generic, AppDbContext appDb)
        {
            _Gen = generic;
            _AppDb = appDb;

        }

        public async Task<Driver> CreateDriverAsync(DriverDTO dto)
        {
            var bus = await _AppDb.Buses.FindAsync(dto.AssignedBusBusId);
            if (bus == null)
                return null; //
            var driver = new Driver
            {
                Name = dto.Name,
                LicenseNumber = dto.LicenseNumber,
                AssignedBusBusId = dto.AssignedBusBusId
            };
            await _Gen.AddAsync(driver);
            await _Gen.SaveAsync();
            return driver;

        }



        public async Task DeleteDriverAsync(int id )
        {
            var driver = await _Gen.GetByIdAsync(id);
            if (driver == null)
                throw new KeyNotFoundException("Driver not found.");
            _Gen.Delete(driver);
            await _Gen.SaveAsync();

        }

        public Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return _Gen.GetAllAsync();
        }

        public async Task<Driver> GetDriverByIdAsync(int id)
        {
            var data = await _Gen.GetByIdAsync(id);
            if (data == null)
                throw new KeyNotFoundException("Driver not found.");
            return data;
        }

        public async Task UpdateDriverAsync(int id, DriverDTO  dto)
        {

            var existingDriver = await _Gen.GetByIdAsync(id);
            if (existingDriver == null)
                throw new KeyNotFoundException("Driver not found.");
            existingDriver.Name = dto.Name;
            existingDriver.LicenseNumber = dto.LicenseNumber;
            existingDriver.AssignedBusBusId = dto.AssignedBusBusId;

            _Gen.Update(existingDriver);
            await _Gen.SaveAsync();

        }

        

    }
}
