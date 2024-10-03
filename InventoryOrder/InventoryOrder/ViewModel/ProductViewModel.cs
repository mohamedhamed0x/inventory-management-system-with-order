using InventoryOrder.Models.intity;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.ViewModel
{
    public class ProductViewModel
    {
        [Display(Name = "Product"), Required(ErrorMessage = "Required")]
        public Product Product { get; set; }

        [Display(Name = "WarehouseName"), Required(ErrorMessage = "Required")]
        public string WarehouseName { get; set; }
    }
}
