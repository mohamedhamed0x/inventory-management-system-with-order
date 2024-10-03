using InventoryOrder.Models.entity;
using InventoryOrder.Models.intity;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.Models.intity
{
    public class Customer
    {
        [Display(Name = "CustomerID"), Required(ErrorMessage = "Required")]

        public int CustomerID { get; set; }
        [Display(Name = "Name"), Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Display(Name = "Address"), Required(ErrorMessage = "Required")]
        public string Address { get; set; }
        [Display(Name = "Phone"), Required(ErrorMessage = "Required")]
        public string Phone { get; set; }
        [Display(Name = "AccountBalance"), Required(ErrorMessage = "Required")]
        public decimal AccountBalance { get; set; }
        [Display(Name = "Orders"), Required(ErrorMessage = "Required")]
        public ICollection<Order> Orders { get; set; }
        [Display(Name = "PaymentCustomers"), Required(ErrorMessage = "Required")]
        public ICollection<PaymentCustomer> PaymentCustomers { get; set; }
    }
}

