using InventoryOrder.Models.intity;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.ViewModel
{
    public class WarehouseDetailsViewModel
    {
        [Display(Name = "WarehouseName"), Required(ErrorMessage = "Required")]
        public string WarehouseName { get; set; }
        [Display(Name = "Location"), Required(ErrorMessage = "Required")]
        public string Location { get; set; }
        [Display(Name = "Products"), Required(ErrorMessage = "Required")]
        public List<Product> Products { get; set; } // إضافة قائمة المنتجات
   }
    


}
