using InventoryOrder.Models.entity;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.Models.intity
{

 
    public class Order
    {
        [Display(Name = "OrderID"), Required(ErrorMessage = "Required")]
        public int OrderID { get; set; }

        [Display(Name = "OrderDate"), Required(ErrorMessage = "Required")]
        public DateTime OrderDate { get; set; }

       [Display(Name = "CustomerID"), Required(ErrorMessage = "Required")]
        public int CustomerID { get; set; }

        [Display(Name = "Customer"), Required(ErrorMessage = "Required")]
        public Customer Customer { get; set; }

        [Display(Name = "TotalAmount"), Required(ErrorMessage = "Required")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "TotalPay"), Required(ErrorMessage = "Required")]
        public decimal TotalPay { get; set; }

        [Display(Name = "TotalRefund"), Required(ErrorMessage = "Required")]
        public decimal TotalRefund { get; set; }

        [Display(Name = "OrderDetails"), Required(ErrorMessage = "Required")]
        public ICollection<OrderDetail> OrderDetails { get; set; }
        // العلاقة مع Warehouse

        [Display(Name = "WarehouseID"), Required(ErrorMessage = "Required")]
        public int WarehouseID { get; set; }

        [Display(Name = "Warehouse"), Required(ErrorMessage = "Required")]
        public Warehouse Warehouse { get; set; }

        [Display(Name = "Payments"), Required(ErrorMessage = "Required")]
        public ICollection<PaymentCustomer> Payments { get; set; }
    }


}
