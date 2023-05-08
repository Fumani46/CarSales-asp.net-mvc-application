using System.ComponentModel.DataAnnotations;

namespace CarSales.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "In Cart")]
        InCart,

        [Display(Name = "Complete")]
        Complete,
    }
}
