using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.ViewModel
{
    public class CustomerAddFundsViewModel
    {

        [Display(Name = "OrderID"), Required(ErrorMessage = "Required")]
        public int OrderID { get; set; }

        [Display(Name = "CustomerID"), Required(ErrorMessage = "Required")]
        public int CustomerID { get; set; }

        [Display(Name = "CustomerName"), Required(ErrorMessage = "Required")]
        public string CustomerName { get; set; }

        [Display(Name = "TotalAmount"), Required(ErrorMessage = "Required")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "TotalPay"), Required(ErrorMessage = "Required")]
        public decimal TotalPay { get; set; }

        [Display(Name = "TotalRefund"), Required(ErrorMessage = "Required")]

        public decimal TotalRefund { get; set; }

        [Display(Name = "AmountToAdd"), Required(ErrorMessage = "Required")]
        public decimal AmountToAdd { get; set; }
    }

}
