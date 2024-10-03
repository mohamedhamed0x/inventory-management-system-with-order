using InventoryOrder.Models.intity;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.ViewModel
{
    public class PurchaseViewModel
    {


        [Display(Name = "Purchase"), Required(ErrorMessage = "Required")]
        public Purchase Purchase { get; set; }


        [Display(Name = "SupplirName"), Required(ErrorMessage = "Required")]
        public string SupplirName { get; set; }


        [Display(Name = "WarehouseName"), Required(ErrorMessage = "Required")]
        public string WarehouseName { get; set; }


        [Display(Name = "PurchaseDetails"), Required(ErrorMessage = "Required")]
        public List<PurchaseDetail> PurchaseDetails { get; set; } // Add this line
    }
}
