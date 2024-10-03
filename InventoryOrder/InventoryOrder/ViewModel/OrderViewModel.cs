using InventoryOrder.Models.intity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.ViewModel
{
    public class OrderViewModel
    {

        [Display(Name = "Order"), Required(ErrorMessage = "Required")]
        public Order Order { get; set; }

        [Display(Name = "CustomerName"), Required(ErrorMessage = "Required")]
        public string CustomerName { get; set; }

        [Display(Name = "WarehouseName"), Required(ErrorMessage = "Required")]
        public string WarehouseName { get; set; }

        [Display(Name = "OrderDetails"), Required(ErrorMessage = "Required")]
        public List<OrderDetail> OrderDetails { get; set; } // Add this line
    }

}
