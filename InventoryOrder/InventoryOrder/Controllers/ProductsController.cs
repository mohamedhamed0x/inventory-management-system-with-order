using InventoryOrder.Models.intity;
using InventoryOrder.Repository;
using InventoryOrder.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryOrder.Controllers
{
    public class ProductsController : Controller
    {


        public  IRepository<Product> _productRepository {  get; set; }
        public  IRepository<Warehouse> _warehouseRepository { get; set; }

        public ProductsController(IRepository<Product> _Productrepository, IRepository<Warehouse> _Warehouserepository)
        {
           
            _productRepository = _Productrepository;
            _warehouseRepository = _Warehouserepository;
        }
        
        public IActionResult Index()
        {
           ViewData["ActivePage"] = "Products";

            var productsWithWarehouse = _productRepository.GetAll()
                .Join(
                    _warehouseRepository.GetAll(),
                    product => product.WarehouseID,
                    warehouse => warehouse.WarehouseID,
                    (product, warehouse) => new ProductViewModel
                    {
                        Product = product,
                        WarehouseName = warehouse.Name
                    }
                ).ToList();

            return View(productsWithWarehouse);
        }

        // GET: ProductsController/Details/5
        // GET: ProductsController/Details/5
        public IActionResult Details(int id)
        {
            ViewData["ActivePage"] = "Products";

            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            // Get the total purchased and sold quantities
            var totalPurchased = _productRepository.GetAll()
                .Where(p => p.ProductID == id)
                .Sum(p => p.OrderDetails.Sum(od => od.Quantity));

            var totalSold = _productRepository.GetAll()
                .Where(p => p.ProductID == id)
                .Sum(p => p.OrderDetails.Sum(sd => sd.Quantity));

            // Find the customer who bought the most of this product
            var topCustomer = _productRepository.GetAll()
                .Where(p => p.ProductID == id)
                .SelectMany(p => p.OrderDetails)
                .GroupBy(od => od.Order.Customer)
                .OrderByDescending(g => g.Sum(od => od.Quantity))
                .FirstOrDefault()?.Key;

            var viewModel = new ProductDetailsViewModel
            {
                Product = product,
                TotalPurchased = totalPurchased,
                TotalSold = totalSold,
                TopCustomer = topCustomer?.Name ?? "No customers"
            };

            return View(viewModel);
        }


        // GET: ProductsController/Create
        [HttpGet]
        public IActionResult Create()
        {
           ViewData["ActivePage"] = "Products";

            ViewBag.Warehouse= new SelectList(_warehouseRepository.GetAll() , "WarehouseID" , "Name");
            return View("Create");
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product Product)
        {
           ViewData["ActivePage"] = "Products";

            try
            {
                _productRepository.Add(Product);
                _productRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Warehouse = new SelectList(_warehouseRepository.GetAll(), "WarehouseID", "Name" , Product.ProductID);
                return View("Create", Product);
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
           ViewData["ActivePage"] = "Products";

            var Cus = _productRepository.GetById(id);
            if (Cus == null)
                return NotFound();
            return View("Edit", Cus);
        }

        // POST: ProductsController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product Product)
        {
           ViewData["ActivePage"] = "Products";

            if (id != Product.ProductID)
            {
                return BadRequest();
            }

            try
            {
                // استدعاء الفانكشن Update لتحديث بيانات العميل
                _productRepository.Update(Product);
                _productRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Product);
            }
        }


    
        // GET: ProductsController/Delete/5
        public IActionResult Delete(int id)
        {
           ViewData["ActivePage"] = "Products";

            var Cus = _productRepository.GetById(id);
            if (Cus == null)
                return NotFound();
            return View("Delete", Cus);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product Product)
        {
           ViewData["ActivePage"] = "Products";

            try
            {
                if (Product == null)
                    return NotFound();

                _productRepository.Delete(id);
                _productRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View("Delete", Product);
            }
        }

      
    }
}
