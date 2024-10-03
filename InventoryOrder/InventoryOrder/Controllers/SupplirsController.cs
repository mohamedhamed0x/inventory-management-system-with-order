using InventoryOrder.Models.intity;
using InventoryOrder.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InventoryOrder.Controllers
{
    public class SupplirsController : Controller
    {
        IRepository<Supplier> repository;

        public SupplirsController(IRepository<Supplier> repository)
        {
            this.repository = repository;
        }

        // GET: SuppliersController
        public IActionResult Index()
        {
                        ViewData["ActivePage"] = "Supplirs";


            var Cuslist = repository.GetAll();

            if (Cuslist == null)
                return NotFound();


            return View("index", Cuslist);
        }

        // GET: SuppliersController/Details/5
        public IActionResult Details(int id)
        {
                        ViewData["ActivePage"] = "Supplirs";

            return View();
        }

        // GET: SuppliersController/Create
        [HttpGet]
        public IActionResult Create()
        {
                        ViewData["ActivePage"] = "Supplirs";

            return View("Create");
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier Supplier)
        {
                        ViewData["ActivePage"] = "Supplirs";

            try
            {
                repository.Add(Supplier);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create", Supplier);
            }
        }

        // GET: SuppliersController/Edit/5
        public ActionResult Edit(int id)
        {
                        ViewData["ActivePage"] = "Supplirs";

            var Cus = repository.GetById(id);
            if (Cus == null)
                return NotFound();
            return View("Edit", Cus);
        }

        // POST: SuppliersController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Supplier Supplier)
        {
                        ViewData["ActivePage"] = "Supplirs";

            if (id != Supplier.SupplierID)
            {
                return BadRequest();
            }

            try
            {
                // استدعاء الفانكشن Update لتحديث بيانات العميل
                repository.Update(Supplier);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Supplier);
            }
        }
        // GET: SuppliersController/Delete/5
        public IActionResult Delete(int id)
        {
                        ViewData["ActivePage"] = "Supplirs";

            var Cus = repository.GetById(id);
            if (Cus == null)
                return NotFound();
            return View("Delete", Cus);
        }

        // POST: SuppliersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Supplier Supplier)
        {
           ViewData["ActivePage"] = "Supplirs";

            try
            {

                if (Supplier == null)
                    return NotFound();

                repository.Delete(id);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View("Delete", Supplier);
            }
        }

      

    }
}
