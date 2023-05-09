using CarSales.Enums;
using System;

namespace CarSales.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public int Quantity { get; set; }

        public double TotalAmount { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModified { get; set; }

        public OrderStatus Status { get; set; }
    }
}
