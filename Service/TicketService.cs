using LoginData.Data;
using LoginData.DTOs;
using LoginData.Model;
using LoginData.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LoginData.Service
{
    public class TicketService : ITicketService
    {
        private readonly IGenericRepository<Ticket> _repo;
        private readonly AppDbContext _app;

        public TicketService(IGenericRepository<Ticket>repository,AppDbContext appDb)
        {
            _repo=repository;
            _app=appDb;
        
        }
        public  async Task<IEnumerable<Ticket>> AllGetdata()
        {
            
            return await _repo.GetAllAsync();
        }

        public async Task<Ticket> CreateAsync(TicketDTO ticketDto)
        {
            var ticket = new Ticket
            {
                PassengerId = ticketDto.PassengerId,
                BusId = ticketDto.BusId,
                SeatNumber = ticketDto.SeatNumber,
                TravelDate = ticketDto.TravelDate
            };

            await _repo.AddAsync(ticket);
            await _repo.SaveAsync();
            return ticket;


        }

        public async Task<Ticket> DeleteAsync(int id )
        {
            var data = await _repo.GetByIdAsync(id);
            if(data==null)
            {
                throw new KeyNotFoundException("Passenger not found.");
            }
             _repo.Delete(data);
            await _repo.SaveAsync();
            return data;
        }

       

        public async  Task<Ticket> GetAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            if(id==null)
            {
                throw new KeyNotFoundException("Passenger not found.");
            }
            return data;
        }

        public  async Task<Ticket> UpdateAsync(int id,TicketDTO ticket)
        {
            var data = await _repo.GetByIdAsync(id);
            if (data==null)
            {
                throw new KeyNotFoundException("Passenger not found.");
            }
            data.PassengerId = ticket.PassengerId;
            data.BusId = ticket.BusId;
            data.SeatNumber = ticket.SeatNumber;
            data.TravelDate = ticket.TravelDate;
             _repo.Update(data);
            await _repo.SaveAsync();
            return data;
                
                
        }

        //public async Task<Ticket> UpdateAsync(int id, Ticket ticket)
        //{
        //    //var existing = await _repo.GetByIdAsync(id);
        //    //if (existing == null)
        //    //{
        //    //    throw new KeyNotFoundException("Ticket not found.");
        //    //}

        //    //// Example field updates (adjust to your model)
        //    //existing.TicketId = ticket.TicketId;
        //    //existing.PassengerId = ticket.PassengerId;
        //    //existing.Date = ticket.Date;

        //    //await _repo.UpdateAsync(existing);
        //    //await _repo.SaveAsync();
        //    //return existing;

        //}
    }
}
