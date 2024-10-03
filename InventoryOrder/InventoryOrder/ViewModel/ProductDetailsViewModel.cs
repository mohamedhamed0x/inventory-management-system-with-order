using InventoryOrder.Models.intity;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.ViewModel
{
    public class ProductDetailsViewModel
    {
        [Display(Name = "Product"), Required(ErrorMessage = "Required")]
        public Product Product { get; set; }      // المنتج
        [Display(Name = "TotalPurchased"), Required(ErrorMessage = "Required")]
        public int TotalPurchased { get; set; }   // إجمالي الكميات المشتراة
        [Display(Name = "TotalSold"), Required(ErrorMessage = "Required")]
        public int TotalSold { get; set; }        // إجمالي الكميات المباعة
        [Display(Name = "TopCustomer"), Required(ErrorMessage = "Required")]
        public string TopCustomer { get; set; }   // أكثر عميل قام بالشراء
    }

}
