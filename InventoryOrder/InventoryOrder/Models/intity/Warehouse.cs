using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.Models.intity
{
    
   public class Warehouse
        {
        [Display(Name = "WarehouseID"), Required(ErrorMessage = "Required")]
        public int WarehouseID { get; set; }
        [Display(Name = "Name"), Required(ErrorMessage = "Required")]
            public string Name { get; set; }
        [Display(Name = "Location"), Required(ErrorMessage = "Required")]
            public string Location { get; set; }

        [Display(Name = "Products"), Required(ErrorMessage = "Required")]    // علاقة One-to-Many مع Product
        public ICollection<Product> Products { get; set; }

        [Display(Name = "Purchases"), Required(ErrorMessage = "Required")]
            // علاقة One-to-Many مع Purchase
            public ICollection<Purchase> Purchases { get; set; }

        [Display(Name = "Orders"), Required(ErrorMessage = "Required")]
            // علاقة One-to-Many مع Order
            public ICollection<Order> Orders { get; set; }

        }

    

}
