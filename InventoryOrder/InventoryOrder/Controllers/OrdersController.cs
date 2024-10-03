using InventoryOrder.Models.intity;
using InventoryOrder.Repository;
using InventoryOrder.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Transactions;

namespace InventoryOrder.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Warehouse> _warehouseRepository;
        private readonly InventoryService _inventoryService;
        public OrdersController(IRepository<Order> orderRepository,InventoryService inventoryService, IRepository<Customer> customerRepository, IRepository<Product> productRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<Warehouse> warehouseRepository)
        {
            _orderRepository = orderRepository;
            _inventoryService = inventoryService;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderDetailRepository = orderDetailRepository;
            _warehouseRepository = warehouseRepository;
        }

        // GET: OrdersController
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "Orders";




            List<OrderViewModel> model = new List<OrderViewModel> ();
            foreach (var item in _orderRepository.GetAll())
            {
                OrderViewModel viewModel = new OrderViewModel
                {
                    Order= item,
                    CustomerName = _customerRepository.GetById(item.CustomerID)?.Name,
                    WarehouseName = _warehouseRepository.GetById(item.WarehouseID)?.Name
                };
                model.Add(viewModel);
            };
            

            return View(model);

        }

        // GET: OrdersController/Details/5
        public IActionResult Details(int id)
        {
            ViewData["ActivePage"] = "Orders";

            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetById(order.CustomerID);
            var warehouse = _warehouseRepository.GetById(order.WarehouseID);

            var orderDetails = _orderDetailRepository.GetAll()
                .Where(od => od.OrderID == id).ToList();

            var model = new OrderViewModel
            {
                Order = order,
                CustomerName = customer?.Name,
                WarehouseName = warehouse?.Name,
                OrderDetails = orderDetails
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ActivePage"] = "Orders";

            var model = new OrderViewModel
            {
                OrderDetails = new List<OrderDetail>()
            };

            ViewBag.Customers = new SelectList(_customerRepository.GetAll(), "CustomerID", "Name");
            ViewBag.Warehouses = new SelectList(_warehouseRepository.GetAll(), "WarehouseID", "Name");
            ViewBag.Products = new SelectList(_productRepository.GetAll(), "ProductID", "Name");

            return View(model);
        }
        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order, List<OrderDetail> orderDetails)
        {
            ViewData["ActivePage"] = "Orders";

            if (order != null && orderDetails != null)
            {
                using (var transaction = new TransactionScope())
                {
                    try
                    {
                        order.TotalAmount = orderDetails.Sum(od => od.Price * od.Quantity);
                        order.TotalRefund = order.TotalAmount - order.TotalPay;

                        var customer = _customerRepository.GetById(order.CustomerID);
                        customer.AccountBalance += order.TotalRefund;
                        _customerRepository.Update(customer);
                        _customerRepository.Save();

                        _orderRepository.Add(order);
                        _orderRepository.Save();

                        foreach (var detail in orderDetails)
                        {
                            detail.OrderID = order.OrderID;
                            _orderDetailRepository.Add(detail);

                            if (!_inventoryService.DecreaseStock(detail.ProductID, detail.Quantity))
                            {
                                ModelState.AddModelError("", $"Insufficient stock for product: {detail.ProductID}");
                                // عند وجود خطأ، إرجاع النموذج مع الأخطاء
                                ViewBag.Customers = new SelectList(_customerRepository.GetAll(), "CustomerID", "Name", order.CustomerID);
                                ViewBag.Warehouses = new SelectList(_warehouseRepository.GetAll(), "WarehouseID", "Name", order.WarehouseID);
                                ViewBag.Products = new SelectList(_productRepository.GetAll(), "ProductID", "Name");

                                var model = new OrderViewModel
                                {
                                    Order = order,
                                    OrderDetails = orderDetails
                                };

                                return View(model);
                            }
                        }

                        _orderDetailRepository.Save();
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

            ViewBag.Customers = new SelectList(_customerRepository.GetAll(), "CustomerID", "Name", order.CustomerID);
            ViewBag.Warehouses = new SelectList(_warehouseRepository.GetAll(), "WarehouseID", "Name", order.WarehouseID);
            ViewBag.Products = new SelectList(_productRepository.GetAll(), "ProductID", "Name");

            var viewModel = new OrderViewModel
            {
                

                Order = order,
                OrderDetails = orderDetails
            };

            return View(viewModel);
        }


        public IActionResult AddProductRow()
        {
            ViewData["ActivePage"] = "Orders";

            var products = _productRepository.GetAll();
            ViewBag.Products = new SelectList(products, "ProductID", "Name");
            return PartialView("_OrderProductRow");
        }
        // POST: OrdersController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Order Order)
        {
            ViewData["ActivePage"] = "Orders";

            if (id != Order.OrderID)
            {
                return BadRequest();
            }

            try
            {
                // استدعاء الفانكشن Update لتحديث بيانات العميل
                _orderRepository.Update(Order);
                _orderRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Order);
            }
        }
        // GET: OrdersController/Delete/5
        public IActionResult Delete(int id)
        {
            ViewData["ActivePage"] = "Orders";

            var Cus = _orderRepository.GetById(id);
            if (Cus == null)
                return NotFound();
            return View("Delete", Cus);
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order Order)
        {
            ViewData["ActivePage"] = "Orders";

            try
            {

                if (Order == null)
                    return NotFound();
                _orderRepository.Delete(id);
                _orderRepository.Save();
                return RedirectToAction(nameof(DeleteSucc));
            }
            catch
            {

                return View("Delete", Order);
            }
        }

        public IActionResult DeleteSucc()
        {
            ViewData["ActivePage"] = "Orders";

            return View("DeleteSucc");
        }
        [HttpPost]
        public IActionResult DeleteSucc(bool ok)
        {
            ViewData["ActivePage"] = "Orders";

            return RedirectToAction(nameof(Index));
        }

       
    }

    
}
