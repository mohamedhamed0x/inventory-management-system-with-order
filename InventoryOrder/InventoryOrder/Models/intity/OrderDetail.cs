using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.Models.intity
{
    public class OrderDetail
    {
        [Display(Name = "OrderDetailID"), Required(ErrorMessage = "Required")]
        public int OrderDetailID { get; set; }

        [Display(Name = "OrderID"), Required(ErrorMessage = "Required")]
        public int OrderID { get; set; }

        [Display(Name = "Order"), Required(ErrorMessage = "Required")]
        public Order Order { get; set; }

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
