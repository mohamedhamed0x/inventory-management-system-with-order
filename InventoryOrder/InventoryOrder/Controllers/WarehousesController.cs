using InventoryOrder.Models.intity;
using InventoryOrder.Repository;
using InventoryOrder.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InventoryOrder.Controllers
{
    public class WarehousesController : Controller
    {
        IRepository<Warehouse> repository;
        private readonly IRepository<Product> _productRepository;

        public WarehousesController(IRepository<Warehouse> repository , IRepository<Product> productRepository)
        {
            this.repository = repository;
            _productRepository = productRepository;
        }

        // GET: _WarehouseRepositorysController
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "Warehouses";

            var Cuslist = repository.GetAll();

            if (Cuslist == null)
                return NotFound();


            return View("index", Cuslist);
        }

        // GET: WarehousesController/Details/5

        public IActionResult Details(int id)
        {
            ViewData["ActivePage"] = "Warehouses";

            var warehouse = repository.GetById(id);
            if (warehouse == null)
                return NotFound();

            // استرجاع جميع المنتجات المرتبطة بالمستودع
            var products = _productRepository.GetAll().Where(p => p.WarehouseID == id).ToList();

            var viewModel = new WarehouseDetailsViewModel
            {
                WarehouseName = warehouse.Name,
                Location = warehouse.Location,
                Products = products // إضافة قائمة المنتجات هنا
            };

            return View(viewModel);
        }

        // GET: WarehousesController/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ActivePage"] = "Warehouses";

            return View("Create");
        }

        // POST: WarehousesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Warehouse Warehouse)
        {
            ViewData["ActivePage"] = "Warehouses";

            try
            {
                repository.Add(Warehouse);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create", Warehouse);
            }
        }

        // GET: WarehousesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["ActivePage"] = "Warehouses";

            var Cus = repository.GetById(id);
            if (Cus == null)
                return NotFound();
            return View("Edit", Cus);
        }

        // POST: WarehousesController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Warehouse Warehouse)
        {
            ViewData["ActivePage"] = "Warehouses";

            if (id != Warehouse.WarehouseID)
            {
                return BadRequest();
            }

            try
            {
                // استدعاء الفانكشن Update لتحديث بيانات العميل
                repository.Update(Warehouse);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Warehouse);
            }
        }
        // GET: WarehousesController/Delete/5
        public IActionResult Delete(int id)
        {
            ViewData["ActivePage"] = "Warehouses";

            var Cus = repository.GetById(id);
            if (Cus == null)
                return NotFound();
            return View("Delete", Cus);
        }

        // POST: WarehousesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Warehouse Warehouse)
        {
            ViewData["ActivePage"] = "Warehouses";

            try
            {

                if (Warehouse == null)
                    return NotFound();
                repository.Delete(id);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View("Delete", Warehouse);
            }
        }

     
    }
}
