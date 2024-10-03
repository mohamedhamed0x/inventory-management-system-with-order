using InventoryOrder.Models.intity;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.ViewModel
{
    public class CustomerPaymentViewModel
    {
        [Display(Name = "Order"), Required(ErrorMessage = "Required")]
        public Order Order { get; set; }
        [Display(Name = "CustomerName"), Required(ErrorMessage = "Required")]
        public string CustomerName { get; set; }

    }


}
