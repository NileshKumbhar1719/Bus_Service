using LoginData.Model;

namespace LoginData.DTOs
{
    public class TicketDTO
    {
        public int PassengerId { get; set; }
        public int BusId { get; set; }
        public int SeatNumber { get; set; }
        public DateTime TravelDate { get; set; }
    }
}
