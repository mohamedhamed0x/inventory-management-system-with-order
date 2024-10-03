using InventoryOrder.Models.intity;
using InventoryOrder.Repository;
using InventoryOrder.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Transactions;

namespace InventoryOrder.Controllers
{
    public class PurchasesController : Controller
    {
       private readonly IRepository<Purchase> _PurchaseRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Warehouse> _warehouseRepository;
        private readonly InventoryService _inventoryService;
        private readonly IRepository<PurchaseDetail> _purchaseDetailRepository;
        private readonly IRepository<Supplier> _supplierRepository;

        public PurchasesController(IRepository<Purchase> _PurchaseRepository ,
            IRepository<Product> _ProductRepository, IRepository<Warehouse> _WarehouseRepository, InventoryService inventoryService,
            IRepository<PurchaseDetail> _PurchaseDetailRepository,IRepository<Supplier> _SupplierRepository)
        {
            this._PurchaseRepository = _PurchaseRepository;
            _productRepository = _ProductRepository;
            _warehouseRepository = _WarehouseRepository;
            _inventoryService = inventoryService;
            _purchaseDetailRepository = _PurchaseDetailRepository;
            _supplierRepository = _SupplierRepository;
        }

        // GET: PurchasesController
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "Purchases";

            List<PurchaseViewModel> model = new List<PurchaseViewModel>();
            foreach (var item in _PurchaseRepository.GetAll())
            {
                PurchaseViewModel viewModel = new PurchaseViewModel
                {
                    Purchase = item,
                    SupplirName = _supplierRepository.GetById(item.SupplierID)?.Name,
                    WarehouseName = _warehouseRepository.GetById(item.WarehouseID)?.Name
                };
                model.Add(viewModel);
            };


            return View(model);
        }

        // GET: PurchasesController/Details/5
        public IActionResult Details(int id)
        {
            ViewData["ActivePage"] = "Orders";

            var purchase = _PurchaseRepository.GetById(id);
            if (purchase == null)
            {
                return NotFound();
            }

            var upplier = _supplierRepository.GetById(purchase.SupplierID);
            var warehouse = _warehouseRepository.GetById(purchase.WarehouseID);

            var purchaseDetails = _purchaseDetailRepository.GetAll()
                .Where(od => od.PurchaseID == id).ToList();

            var model = new PurchaseViewModel
            {
                Purchase = purchase,
                SupplirName = upplier?.Name,
                WarehouseName = warehouse?.Name,
                PurchaseDetails = purchaseDetails
            };

            return View(model);
        }

        // GET: PurchasesController/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ActivePage"] = "Purchases";

            var model = new PurchaseViewModel
            {
                PurchaseDetails = new List<PurchaseDetail>()
            };

            // تأكد من استخدام المفاتيح الصحيحة
            ViewBag.Products = new SelectList(_productRepository.GetAll(), "ProductID", "Name");
            ViewBag.Suppliers = new SelectList(_supplierRepository.GetAll(), "SupplierID", "Name");
            ViewBag.Warehouses = new SelectList(_warehouseRepository.GetAll(), "WarehouseID", "Name");

            return View(model); // تمرير النموذج إلى العرض
        }


        // POST: PurchasesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Purchase Purchase, List<PurchaseDetail> PurchaseDetails)
        {
                        ViewData["ActivePage"] = "Purchases";

            if (Purchase != null && PurchaseDetails != null)
            {
                using (var transaction = new TransactionScope())
                {
                    try
                    {
                        Purchase.TotalAmount = PurchaseDetails.Sum(od => od.Price * od.Quantity);
                        Purchase.TotalRefund = Purchase.TotalAmount - Purchase.TotalPay;

                        var supplier = _supplierRepository.GetById(Purchase.SupplierID);
                        supplier.AccountBalance += Purchase.TotalRefund;
                        _supplierRepository.Update(supplier);
                        _supplierRepository.Save();

                        _PurchaseRepository.Add(Purchase);
                        _PurchaseRepository.Save();

                        foreach (var detail in PurchaseDetails)
                        {
                            detail.PurchaseID = Purchase.PurchaseID;
                            _purchaseDetailRepository.Add(detail);

                            if (!_inventoryService.IncreaseStock(detail.ProductID, detail.Quantity))
                            {
                                ModelState.AddModelError("", $"Insufficient stock for product: {detail.ProductID}");
                                // عند وجود خطأ، إرجاع النموذج مع الأخطاء
                                ViewBag.Customers = new SelectList(_supplierRepository.GetAll(), "CustomerID", "Name", Purchase.SupplierID);
                                ViewBag.Warehouses = new SelectList(_warehouseRepository.GetAll(), "WarehouseID", "Name", Purchase.WarehouseID);
                                ViewBag.Products = new SelectList(_productRepository.GetAll(), "ProductID", "Name");

                                var model = new PurchaseViewModel
                                {
                                    Purchase = Purchase,
                                    PurchaseDetails = PurchaseDetails
                                };

                                return View(model);
                            }
                        }

                        _purchaseDetailRepository.Save();
                        transaction.Complete();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        // إذا حدث أي استثناء آخر، أضف الخطأ إلى نموذج الحالة
                        ModelState.AddModelError("", ex.Message);
                    }
                }
            }

            ViewBag.Customers = new SelectList(_supplierRepository.GetAll(), "CustomerID", "Name", Purchase.PurchaseID);
            ViewBag.Warehouses = new SelectList(_warehouseRepository.GetAll(), "WarehouseID", "Name", Purchase.WarehouseID);
            ViewBag.Products = new SelectList(_productRepository.GetAll(), "ProductID", "Name");

            var viewModel = new PurchaseViewModel
            {
                Purchase = Purchase,
                PurchaseDetails = PurchaseDetails
            };

            return View(viewModel);
        }
        // GET: PurchasesController/Edit/5
        public ActionResult Edit(int id)
        {
                                    ViewData["ActivePage"] = "Purchases";

            var Cus = _PurchaseRepository.GetById(id);
            if (Cus == null)
                return NotFound();
            return View("Edit", Cus);
        }

        // POST: PurchasesController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Purchase Purchase)
        {
           ViewData["ActivePage"] = "Purchases";

            if (id != Purchase.PurchaseID)
            {
                return BadRequest();
            }

            try
            {
                // استدعاء الفانكشن Update لتحديث بيانات العميل
                _PurchaseRepository.Update(Purchase);
                _PurchaseRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Purchase);
            }
        }
        // GET: PurchasesController/Delete/5
        public IActionResult Delete(int id)
        {
                        ViewData["ActivePage"] = "Purchases";

            var Cus = _PurchaseRepository.GetById(id);
            if (Cus == null)
                return NotFound();

            return View("Delete", Cus);
        }

        // POST: PurchasesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Purchase Purchase)
        {
             ViewData["ActivePage"] = "Purchases";

            try
            {

                if (Purchase == null)
                    return NotFound();

                _PurchaseRepository.Delete(id);
                _PurchaseRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View("Delete", Purchase);
            }
        }

        
    }
}
