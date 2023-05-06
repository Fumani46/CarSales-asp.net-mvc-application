using System;
using System.ComponentModel.DataAnnotations;

namespace CarSales.Models.Items
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string CarName { get; set; }
        [Required]
        public string CarModel { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
