namespace LoginData.Model
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }

        public int AssignedBusBusId { get; set; }
        public Bus AssignedBus { get; set; }  
    }

}
