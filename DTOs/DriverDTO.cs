using LoginData.Model;
using System.ComponentModel.DataAnnotations;

namespace LoginData.DTOs
{
    public class DriverDTO
    {
        [Required(ErrorMessage = "Driver name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "License number is required")]
        public string LicenseNumber { get; set; }

        [Required(ErrorMessage = "BusId is required")]
        public int AssignedBusBusId { get; set; }

    }
}
