using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.Models.intity
{
    public class PurchaseDetail
    {
        [Display(Name = "PurchaseDetailID"), Required(ErrorMessage = "Required")]
        public int PurchaseDetailID { get; set; }

        [Display(Name = "PurchaseID"), Required(ErrorMessage = "Required")]
        public int PurchaseID { get; set; }

        [Display(Name = "Purchase"), Required(ErrorMessage = "Required")]
        public Purchase Purchase { get; set; }

        [Display(Name = "ProductID"), Required(ErrorMessage = "Required")]
        public int ProductID { get; set; }

        [Display(Name = "Product"), Required(ErrorMessage = "Required")]
        public Product Product { get; set; }
        [Display(Name = "Quantity"), Required(ErrorMessage = "Required")]
        public int Quantity { get; set; }
        [Display(Name = "Price"), Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }
    }

}
