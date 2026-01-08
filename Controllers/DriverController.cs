using LoginData.DTOs;
using LoginData.Model;
using LoginData.Repository;
using LoginData.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _Dri;

        public DriverController(IDriverService driverService) 
        {
           this._Dri = driverService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _Dri.GetAllDriversAsync();
            return Ok(drivers);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDriver(DriverDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var driver = await _Dri.CreateDriverAsync(dto);

            if (driver == null)
                return BadRequest(new { message = "Assigned Bus does not exist" });

            return Ok(driver);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            var driver = await _Dri.GetDriverByIdAsync(id);
            return Ok(driver);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, DriverDTO dto)
        {
            await _Dri.UpdateDriverAsync(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            await _Dri.DeleteDriverAsync(id);
            return NoContent();
        }
    }
}
