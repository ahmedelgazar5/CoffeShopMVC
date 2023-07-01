using Coffe_Shop_MVC.Models;
namespace Coffe_Shop_MVC.Repository.OrderRepo
{
    public class OrderRepository:IOrderRepository
    {
        CoffeContext _context;
        public OrderRepository(CoffeContext _context)
        {
            this._context = _context;
            
        }
        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            Save();
        }
        public void Update(Order order)
        {
            _context.Orders.Update(order);
            Save();
        }
        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
