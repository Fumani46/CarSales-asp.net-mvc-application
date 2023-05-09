using System.ComponentModel.DataAnnotations;

namespace CarSales.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string CarId { get; set; }
        public string CarName { get; set; }

        public string CarModel { get; set; }

        public string CusId { get; set; }


    }
}
