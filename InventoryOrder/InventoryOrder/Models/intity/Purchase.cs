using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace InventoryOrder.Models.intity
{
  
    public class Purchase
    {
        [Display(Name = "PurchaseID"), Required(ErrorMessage = "Required")]
        public int PurchaseID { get; set; }
        [Display(Name = "PurchaseDate"), Required(ErrorMessage = "Required")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "SupplierID"), Required(ErrorMessage = "Required")]

        public int SupplierID { get; set; }
        [Display(Name = "Supplier"), Required(ErrorMessage = "Required")]

        public Supplier Supplier { get; set; }
        [Display(Name = "TotalAmount"), Required(ErrorMessage = "Required")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "TotalPay"), Required(ErrorMessage = "Required")]
        public decimal TotalPay { get; set; }
        [Display(Name = "TotalRefund"), Required(ErrorMessage = "Required")]
        public decimal TotalRefund { get; set; }

        [Display(Name = "PurchaseDetails"), Required(ErrorMessage = "Required")]

        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }

        [Display(Name = "WarehouseID"), Required(ErrorMessage = "Required")]

        // العلاقة مع Warehouse
        public int WarehouseID { get; set; }

        [Display(Name = "Warehouse"), Required(ErrorMessage = "Required")]
        public Warehouse Warehouse { get; set; }

        [Display(Name = "Payments"), Required(ErrorMessage = "Required")]

        public ICollection<PaymentSupplier> Payments { get; set; }


        
    }


}
