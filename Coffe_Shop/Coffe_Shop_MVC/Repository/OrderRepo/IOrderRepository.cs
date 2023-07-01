using Coffe_Shop_MVC.Models;
namespace Coffe_Shop_MVC.Repository.OrderRepo
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        void Save();
    }
}
