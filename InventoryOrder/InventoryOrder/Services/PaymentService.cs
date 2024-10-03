using InventoryOrder.Models.entity;
using InventoryOrder.Models.intity;
using InventoryOrder.Repository;

using System.Transactions;

public class PaymentService 
{
    private readonly IRepository<Purchase> _purchaseRepository ;
    public IRepository<PaymentCustomer> _customerPaymentRepository { get; }
    public IRepository<PaymentSupplier> _supplierPaymentRepository { get; }
    public IRepository<Order> _orderRepository { get; }
    public IRepository<Customer> _customerRepository { get; }
    public IRepository<Supplier> _supplierRepository { get; }

    public PaymentService(IRepository<PaymentCustomer> _coutomerPaymentRepository,
        IRepository<PaymentSupplier> _supplierPaymentRepository,
        IRepository<Order> _orderRepository, IRepository<Customer> _customerRepository,
        IRepository<Purchase> _purchaseRepository , IRepository<Supplier> _SupplierRepository
        )
    {
        this._customerPaymentRepository = _coutomerPaymentRepository;
        this._supplierPaymentRepository = _supplierPaymentRepository;
        this._orderRepository = _orderRepository;
        this._customerRepository = _customerRepository;
        this._purchaseRepository = _purchaseRepository;
        this._supplierRepository = _SupplierRepository;
    }

   public bool CustomerDecreaseRufund( int orderId, decimal TotalRefund )
    {
        try
        {
            var order = _orderRepository.GetById( orderId );
            var curomer =_customerRepository.GetById(order.CustomerID );
            using (var transtion = new TransactionScope())
            {

                order.TotalPay += TotalRefund;
                order.TotalRefund -= TotalRefund;
                _orderRepository.Update(order);
                _orderRepository.Save();
                var customerPayment = new PaymentCustomer
                {
                    Amount = TotalRefund,
                    CustomerID = order.CustomerID,
                    OrderID = order.OrderID,
                    PaymentDate = DateTime.Now,

                };
                _customerPaymentRepository.Add(customerPayment);
                _customerPaymentRepository.Save();
                
                curomer.AccountBalance -= TotalRefund;
                _customerRepository.Update(curomer);
                _customerRepository.Save();

                transtion.Complete();
            }
            return true;

        }
        catch (Exception ex) 
        {
            return false;
        }
        return false;
    }


    public bool SupplierDecreaseRufund(int purchaseId, decimal TotalRefund)
    {
        try
        {
            var purchase = _purchaseRepository.GetById(purchaseId);
            var supplier = _supplierRepository.GetById(purchase.SupplierID);
            using (var transtion = new TransactionScope())
            {

                purchase.TotalPay += TotalRefund;
                purchase.TotalRefund -= TotalRefund;
                _purchaseRepository.Update(purchase);
                _purchaseRepository.Save();
                var supplierPayment = new PaymentSupplier
                {
                    Amount = TotalRefund,
                    SupplierID = purchase.SupplierID,
                    PurchaseID = purchase.PurchaseID,
                    Paymentdate = DateTime.Now,

                };
                _supplierPaymentRepository.Add(supplierPayment);
                _supplierPaymentRepository.Save();

                supplier.AccountBalance -= TotalRefund;
                _supplierRepository.Update(supplier);
                _supplierRepository.Save();

                transtion.Complete();
            }
            return true;

        }
        catch (Exception ex)
        {
            return false;
        }
        return false;
    }



}
