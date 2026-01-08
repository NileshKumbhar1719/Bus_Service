using LoginData.DTOs;
using LoginData.Model;

namespace LoginData.Service
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> AllGetdata();
        Task<Ticket> CreateAsync(TicketDTO ticket);
        Task<Ticket> UpdateAsync(int id,TicketDTO ticket);
        Task<Ticket> DeleteAsync(int id);
        Task<Ticket> GetAsync(int id);
        
    }
}
