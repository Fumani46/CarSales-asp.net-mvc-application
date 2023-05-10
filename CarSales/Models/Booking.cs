using System.ComponentModel.DataAnnotations;

namespace CarSales.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }

        public string CarModel { get; set; }

        public int CusId { get; set; }


    }
}
