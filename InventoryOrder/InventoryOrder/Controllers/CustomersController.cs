
using InventoryOrder.Models.entity;
using InventoryOrder.Models.intity;
using InventoryOrder.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryOrder.Controllers
{

    public class CustomersController : Controller
    {
        IRepository<Customer> _customerRepository;
        private readonly IRepository<PaymentCustomer> _paymentRepository;
        private readonly IRepository<Order> _orderRepository;

        public CustomersController(IRepository<Customer> repository , IRepository<PaymentCustomer> paymentRepository,
            IRepository<Order> orderRepository)
        {
            _customerRepository = repository;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
        }

        //        GET: CustomersController
        public IActionResult Index()
        {
            ViewData["ActivePage"]= "Customers";
            var Cuslist = _customerRepository.GetAll();

            if (Cuslist == null)
                return NotFound();


            return View("index", Cuslist);
        }

        //GET: CustomersController/Details/5
        // GET: Customer/Details/5
        public IActionResult Details(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            // استرداد الطلبات
            customer.Orders = _orderRepository.GetOrdersByCustomerId(id); // قم بإنشاء هذه الدالة في `OrderRepository`

            // استرداد العمليات المالية
            customer.PaymentCustomers = _paymentRepository.GetPaymentsByCustomerId(id); // قم بإنشاء هذه الدالة في `PaymentRepository`

            return View(customer);
        }


        //  GET: CustomersController/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ActivePage"] = "Customers";

            return View("Create");
        }

        //  POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            ViewData["ActivePage"] = "Customers";

            try
            {
                _customerRepository.Add(customer);
                _customerRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create", customer);
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["ActivePage"] = "Customers";

            var Cus = _customerRepository.GetById(id);
            if (Cus == null)
                return NotFound();
            return View("Edit", Cus);
        }

        /// POST: CustomersController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            ViewData["ActivePage"] = "Customers";

            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            try
            {
                //      استدعاء الفانكشن Update لتحديث بيانات العميل
                _customerRepository.Update(customer);
                _customerRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }
        //GET: CustomersController/Delete/5
        public IActionResult Delete(int id)
        {
            ViewData["ActivePage"] = "Customers";

            var Cus = _customerRepository.GetById(id);
            if (Cus == null)
                return NotFound();
            return View("Delete", Cus);
        }

        //  POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            ViewData["ActivePage"] = "Customers";

            try
            {

                if (customer == null)
                    return NotFound();

                _customerRepository.Delete(id);
                _customerRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View("Delete", customer);
            }
        }

    }
}
