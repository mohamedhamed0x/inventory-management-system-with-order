using InventoryOrder.Models.intity;
using InventoryOrder.Repository;
using InventoryOrder.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace InventoryOrder.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Purchase> _purchaseRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Supplier> _supplierrRpository;
        private readonly PaymentService _paymentService;

        public PaymentsController(
            IRepository<Order> orderRepository,
            IRepository<Purchase> purchaseRepository, 
            IRepository<Customer> customerRepository , 
            IRepository<Supplier> SupplierrRpository,PaymentService _paymentService
            )
        {

            _orderRepository = orderRepository;
            _purchaseRepository = purchaseRepository;
            _customerRepository = customerRepository;
            _supplierrRpository = SupplierrRpository;
            this._paymentService = _paymentService;
        }

        // GET: Payments/Index
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "Payments";

            var orders = _orderRepository.GetAll();
           List<CustomerPaymentViewModel > ordersList = new List<CustomerPaymentViewModel>();
            foreach (var order in orders)
            {
                if (order.TotalRefund > 0)
                {
                    var CusPay = new CustomerPaymentViewModel
                    {
                        Order = order,
                        CustomerName = _customerRepository.GetById(order.CustomerID).Name,
                    };

                    ordersList.Add(CusPay);

                }
               
            }

            ViewBag.Orders= ordersList;

            var purchases = _purchaseRepository.GetAll();
            List<SupplierPaymentViewModel> purchasesList = new List<SupplierPaymentViewModel>();
            foreach (var purchase in purchases)
            {
                if (purchase.TotalRefund > 0)
                {
                    var SupPay = new SupplierPaymentViewModel
                    {
                        Purchase = purchase,
                        SupplierName = _supplierrRpository.GetById(purchase.SupplierID).Name,
                    };
                    purchasesList.Add(SupPay);
                }
               
            }
            ViewBag.Purchases= purchasesList;

           // var model = new Tuple<List<CustomerPaymentViewModel>, List<SupplierPaymentViewModel>>(ordersList, purchasesList);

            return View(/*model*/);
        }


        [HttpGet]
        public IActionResult AddFundsToOrder(int id)
        {
            ViewData["ActivePage"] = "Payments";

            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            var model = new CustomerAddFundsViewModel
            {
                OrderID = order.OrderID,
                TotalAmount = order.TotalAmount,
                TotalPay = order.TotalPay,
                TotalRefund = order.TotalRefund,
                CustomerID = order.CustomerID,
                CustomerName =_customerRepository.GetById(order.CustomerID).Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFundsToOrder(CustomerAddFundsViewModel model)
        {
            ViewData["ActivePage"] = "Payments";

            if (ModelState.IsValid)
            {
                if (model.TotalRefund >= model.AmountToAdd)
                {
                    if (!_paymentService.CustomerDecreaseRufund(model.OrderID, model.AmountToAdd))
                    {
                        return NotFound();
                    }
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", $"must (TotalRefund >= AmountToAdd ) ");

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AddFundsToPurchase(int id)
        {
            ViewData["ActivePage"] = "Payments";

            var purchase = _purchaseRepository.GetById(id);
            if (purchase == null)
            {
                return NotFound();
            }

            var model = new SupplierAddFundsViewModel
            {
                PurchaseID = purchase.PurchaseID,
                TotalAmount = purchase.TotalAmount,
                TotalPay = purchase.TotalPay,
                TotalRefund = purchase.TotalRefund,
                SupplierID= purchase.SupplierID,
                SupplierName = _supplierrRpository.GetById(purchase.SupplierID).Name,


            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFundsToPurchase(SupplierAddFundsViewModel model)
        {
            ViewData["ActivePage"] = "Payments";

            if (ModelState.IsValid)
            {
                
                if (_paymentService.SupplierDecreaseRufund(model.SupplierID ,model.AmountToAdd))
                {
                    return NotFound();
                }


                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}