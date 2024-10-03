using InventoryOrder.Models.intity;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.ViewModel
{
    public class SupplierPaymentViewModel
    {
        [Display(Name = "Purchase"), Required(ErrorMessage = "Required")]
        public Purchase Purchase { get; set; }
        [Display(Name = "SupplierName"), Required(ErrorMessage = "Required")]
        public string SupplierName { get; set; }
    }
    


}
