using LoginData.DTOs;
using LoginData.Model;
using LoginData.Repository;


namespace LoginData.Service
{
    public class BusService : IBusService
    {
        private readonly IGenericRepository<Bus> _busRepo;
        private readonly IGenericRepository<BusRound> _roundRepo;

        public BusService(
            IGenericRepository<Bus> busRepo,
            IGenericRepository<BusRound> roundRepo)
        {
            _busRepo = busRepo;
            _roundRepo = roundRepo;
        }

        public async Task<IEnumerable<Bus>> GetAllBusesAsync()
        {
            return await _busRepo.GetAllAsync();
        }

        public async Task<Bus> GetBusByIdAsync(int id)
        {
            return await _busRepo.GetByIdAsync(id);
        }

        public async Task<Bus> CreateBusAsync(BusDto dto)
        {
            var bus = new Bus
            {
                PlateNumber = dto.PlateNumber,
                Capacity = dto.Capacity,
                ImageUrl = dto.ImageUrl,
                RoundId = dto.RoundId
            };

            await _busRepo.AddAsync(bus);
            await _busRepo.SaveAsync();
            return bus;
        }

        public async Task UpdateBusAsync(int id, BusDto dto)
        {
            var bus = await _busRepo.GetByIdAsync(id);
            if (bus == null)
                throw new Exception("Bus not found");

            bus.PlateNumber = dto.PlateNumber;
            bus.Capacity = dto.Capacity;
            bus.ImageUrl = dto.ImageUrl;
            bus.RoundId = dto.RoundId;

            _busRepo.Update(bus);
            await _busRepo.SaveAsync();
        }

        public async Task DeleteBusAsync(int id)
        {
            var bus = await _busRepo.GetByIdAsync(id);
            if (bus == null)
                throw new Exception("Bus not found");

            _busRepo.Delete(bus);
            await _busRepo.SaveAsync();
        }

        public async Task<BusRound> CreateBusRoundAsync(BusRoundDto dto)
        {
            var round = new BusRound
            {
                StartPoint = dto.StartPoint,
                EndPoint = dto.EndPoint,
                StopsJson = dto.StopsJson
            };

            await _roundRepo.AddAsync(round);
            await _roundRepo.SaveAsync();
            return round;
        }
    }
}
