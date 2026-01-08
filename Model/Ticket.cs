namespace LoginData.Model
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public Passenger Passenger { get; set; }
        public int PassengerId { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public int SeatNumber { get; set; }
        public DateTime TravelDate { get; set; }
    }
}
