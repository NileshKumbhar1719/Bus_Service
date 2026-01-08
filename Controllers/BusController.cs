using LoginData.DTOs;
using LoginData.Service;

using Microsoft.AspNetCore.Mvc;

namespace LoginData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _service;

        public BusController(IBusService service)
        {
            _service = service;
        }

        
        [HttpPost("round")]
        public async Task<IActionResult> CreateRound(BusRoundDto dto)
            => Ok(await _service.CreateBusRoundAsync(dto));

        // CREATE BUS
        [HttpPost]
        public async Task<IActionResult> CreateBus(BusDto dto)
            => Ok(await _service.CreateBusAsync(dto));

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllBusesAsync());

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _service.GetBusByIdAsync(id));

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BusDto dto)
        {
            await _service.UpdateBusAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteBusAsync(id);
            return NoContent();
        }
    }
}
