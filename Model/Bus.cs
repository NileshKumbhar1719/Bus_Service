namespace LoginData.Model
{
    public class Bus
    {
        public int BusId { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public string ImageUrl { get; set; }
        public int RoundId { get; set; }
        public BusRound Round { get; set; }  // Navigation property
    }
}
