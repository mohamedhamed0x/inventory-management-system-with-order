using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.Models.intity
{
    public class PaymentSupplier
    {

        [Display(Name = "PaymentSupplierID"), Required(ErrorMessage = "Required")]
        public int PaymentSupplierID { get; set; }

        [Display(Name = "Paymentdate"), Required(ErrorMessage = "Required")]
        public DateTime Paymentdate { get; set; }

        [Display(Name = "Amount"), Required(ErrorMessage = "Required")]
        public decimal Amount { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        [Display(Name = "PurchaseID"), Required(ErrorMessage = "Required")]
        public int PurchaseID { get; set; }

        [Display(Name = "SupplierID"), Required(ErrorMessage = "Required")]
        public int SupplierID { get; set; }

        [Display(Name = "Purchase"), Required(ErrorMessage = "Required")]
        public Purchase Purchase { get; set; }

        [Display(Name = "Supplier"), Required(ErrorMessage = "Required")]
        public Supplier Supplier { get; set; }

    }

}
