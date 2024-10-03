using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.Models.intity
{
    public class Supplier
    {
        [Display(Name = "SupplierID"), Required(ErrorMessage = "Required")]
        public int SupplierID { get; set; }
        [Display(Name = "Name"), Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Display(Name = "Address"), Required(ErrorMessage = "Required")]
        public string Address { get; set; }
        [Display(Name = "Phone"), Required(ErrorMessage = "Required")]
        public string Phone { get; set; }
        [Display(Name = "AccountBalance"), Required(ErrorMessage = "Required")]
        public decimal AccountBalance { get; set; }

        [Display(Name = "Purchases"), Required(ErrorMessage = "Required")]
        public ICollection<Purchase> Purchases { get; set; }

        [Display(Name = "PaymentSuppliers"), Required(ErrorMessage = "Required")]
        public ICollection<PaymentSupplier> PaymentSuppliers { get; set; }

    }

}
