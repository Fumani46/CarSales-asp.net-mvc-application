using System;
using System.ComponentModel.DataAnnotations;
using CarSales.Enums;

namespace CarSales.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public double CarPrice { get; set; }

        public int CustomerId { get; set; }

        public int Quantity { get; set; }

        public double TotalAmount { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModified { get; set; }

        public OrderStatus Status { get; set; }
    }
}
