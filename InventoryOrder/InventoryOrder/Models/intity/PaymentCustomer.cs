using InventoryOrder.Models.intity;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.Models.entity
{
    public class PaymentCustomer
    {
        [Display(Name = "PaymentDate"), Required(ErrorMessage = "Required")]
        public int PaymentCustomerID { get; set; }
        [Display(Name = "PaymentDate"), Required(ErrorMessage = "Required")]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Amount"), Required(ErrorMessage = "Required")]
        public decimal Amount { get; set; }

        [Display(Name = "OrderID"), Required(ErrorMessage = "Required")]
        public int OrderID { get; set; }

        [Display(Name = "CustomerID"), Required(ErrorMessage = "Required")]
        public int CustomerID { get; set; }

        [Display(Name = "Order"), Required(ErrorMessage = "Required")]
        public Order Order { get; set; }

        [Display(Name = "Customer"), Required(ErrorMessage = "Required")]
        public Customer Customer { get; set; }
    }
}
