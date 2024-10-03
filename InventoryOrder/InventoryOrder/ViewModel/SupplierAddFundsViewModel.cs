using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.ViewModel
{
    public class SupplierAddFundsViewModel
    {

        [Display(Name = "PurchaseID"), Required(ErrorMessage = "Required")]
        public int PurchaseID{ get; set; }

        [Display(Name = "SupplierID"), Required(ErrorMessage = "Required")]
        public int SupplierID { get; set; }

        [Display(Name = "SupplierName"), Required(ErrorMessage = "Required")]
        public string SupplierName{ get; set; }

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
