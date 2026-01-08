using LoginData.DTOs;
using LoginData.Model;
using LoginData.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundBUS : ControllerBase
    {
        private readonly IRoundService _roundService;

        public RoundBUS(IRoundService roundService)
        {
            _roundService = roundService;
        }

        // GET: api/BusRound
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusRound>>> GetAll()
        {
            var rounds = await _roundService.GetAllAsync();
            return Ok(rounds);
        }

        // GET: api/BusRound/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusRound>> GetById(int id)
        {
            try
            {
                var round = await _roundService.GetByIdAsync(id);
                return Ok(round);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/BusRound
        [HttpPost]
        public async Task<ActionResult<BusRound>> Create([FromBody] BusRoundDto dto)
        {
            var round = new BusRound
            {
                StartPoint = dto.StartPoint,
                EndPoint = dto.EndPoint,
                StopsJson = dto.StopsJson
            };

            await _roundService.AddAsync(round);
            return CreatedAtAction(nameof(GetById), new { id = round.RoundId }, round);
        }

        // PUT: api/BusRound/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BusRoundDto dto)
        {
            try
            {
                var round = await _roundService.GetByIdAsync(id);
                round.StartPoint = dto.StartPoint;
                round.EndPoint = dto.EndPoint;
                round.StopsJson = dto.StopsJson;

                await _roundService.UpdateAsync(round);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/BusRound/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _roundService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
