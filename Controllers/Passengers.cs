using LoginData.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace LoginData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Passengers : ControllerBase
    {
        private readonly IPassengerService _service;

        public Passengers(IPassengerService service)
        {
            _service = service;
        
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data= await _service.GettAllDATA();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetDATAById(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Model.Passenger passenger)
        {
            var data = await _service.CreateDATA(passenger);
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Model.Passenger passenger)
        {
            await _service.UpdateDATA(id, passenger);
            return Ok(new { message = "Passenger successfully Update" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteDATA(id);
            return Ok(new { message = "Passenger successfully deleted" });
        }


    }
}
