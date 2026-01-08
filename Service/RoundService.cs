using LoginData.Controllers;
using LoginData.Data;
using LoginData.DTOs;
using LoginData.Model;
using LoginData.Repository;

namespace LoginData.Service
{
    public class RoundService : IRoundService
    {
        private readonly IGenericRepository<BusRound> _roundRepo;

        public RoundService(IGenericRepository<BusRound> roundRepo)
        {
            _roundRepo = roundRepo;
        }

        public async Task<IEnumerable<BusRound>> GetAllAsync()
        {
            var rounds= await _roundRepo.GetAllAsync();
            return rounds.Select(r => new BusRound
            {
                RoundId = r.RoundId,
                StartPoint = r.StartPoint,
                EndPoint = r.EndPoint,
                StopsJson = r.StopsJson
            });
        }

        public async Task<BusRound> GetByIdAsync(int id)
        {
            var round = await _roundRepo.GetByIdAsync(id);
            if (round == null)
                throw new KeyNotFoundException("Bus round not found.");

            return round;
        }

        public async Task AddAsync(BusRound round)
        {
            await _roundRepo.AddAsync(round);
            await _roundRepo.SaveAsync();
        }

        public async Task UpdateAsync(BusRound round)
        {
            _roundRepo.Update(round);
            await _roundRepo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var round = await _roundRepo.GetByIdAsync(id);
            if (round == null)
                throw new KeyNotFoundException("Bus round not found.");

            _roundRepo.Delete(round);
            await _roundRepo.SaveAsync();
        }
    }

}
