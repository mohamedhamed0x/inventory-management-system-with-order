using InventoryOrder.Models.entity;
using InventoryOrder.Models.intity;

namespace InventoryOrder.ViewModel
{
    public class CustomerDetailViewModel
    {
        public Customer Customer { get; set; }
        public List<Order> Orders { get; set; }
        public List<PaymentCustomer> DepositTransactions { get; set; } // Assuming you have a DepositTransaction model
    }

}
