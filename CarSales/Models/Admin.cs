using System.ComponentModel.DataAnnotations;

namespace CarSales.Models
{
    public class Admin
    {
        [Key]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

