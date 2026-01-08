namespace LoginData.DTOs
{
    public class BusRoundDto
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public List<string> StopsJson { get; set; }
    }
}
