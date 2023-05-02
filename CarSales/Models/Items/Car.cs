using System;
using System.ComponentModel.DataAnnotations;

namespace CarSales.Models.Items
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string Color { get; set; }
        public DateTime Year { get; set; }
        public string Type { get; set; }

        public string Url { get; set; }

    }
}
