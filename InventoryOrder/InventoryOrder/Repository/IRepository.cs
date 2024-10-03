using InventoryOrder.Models.entity;
using InventoryOrder.Models.intity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryOrder.Repository
{
    public interface IRepository<T> where T : class
    {
        public void Add(T obj);

        public void Update(T obj);

        public void Delete(int id);

        public List<T> GetAll();

        public T GetById(int id);

        public void Save();

        public int CountNumber();
        public List<T> GetGroup(Expression<Func<T, bool>> func);
        public List<Order> GetOrdersByCustomerId(int customerId);

        public List<PaymentCustomer> GetPaymentsByCustomerId(int customerId);
        
        //  public List<T> GetByDEptID(int deptID);
    }
}
