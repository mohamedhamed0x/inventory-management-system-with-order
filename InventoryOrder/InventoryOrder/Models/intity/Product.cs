using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.Models.intity
{
    public class Product
    {

        [Display(Name = "ProductID"), Required(ErrorMessage = "Required")]
        public int ProductID { get; set; }

        [Display(Name = "Name"), Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Display(Name = "PurchasePrice"), Required(ErrorMessage = "Required")]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "SellingPrice"), Required(ErrorMessage = "Required")]
        public decimal SellingPrice { get; set; }

        [Display(Name = "QuantityInStock"), Required(ErrorMessage = "Required")]
        public int QuantityInStock { get; set; }

        [Display(Name = "OrderDetails"), Required(ErrorMessage = "Required")]
        public ICollection<OrderDetail> OrderDetails { get; set; }

        [Display(Name = "PurchaseDetails"), Required(ErrorMessage = "Required")]
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }

        [Display(Name = "WarehouseID"), Required(ErrorMessage = "Required")]

        public int WarehouseID { get; set; }

        [Display(Name = "Warehouse"), Required(ErrorMessage = "Required")]
        public Warehouse Warehouse { get; set; }
    }

}
