using LoginData.DTOs;
using LoginData.Model;
using LoginData.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsAPI : ControllerBase
    {
        private readonly ITicketService _Ti;

        public TicketsAPI(ITicketService ticketService)
        {
            _Ti = ticketService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _Ti.AllGetdata();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateData([FromBody] TicketDTO ticket)
        {
            var data = await _Ti.CreateAsync(ticket);
            return Ok(data);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetdataID(int id)
        {
           var data= await _Ti.GetAsync(id);
            return Ok(data);
            

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id ,[FromBody]TicketDTO ticket)
        {
             await _Ti.UpdateAsync(id,ticket);
            return Ok(new { message = "Ticket  successfully Update" });



        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _Ti.DeleteAsync(id);
            return Ok(new { message = "Passenger successfully deleted" });
        }
        
    }
}
