using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace LoginData.Model
{
    
    public class BusRound
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoundId { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }

      
       
        public List<string> StopsJson { get; set; }= new List<string>();


        public ICollection<Bus> Buses { get; set; }
    }
}
