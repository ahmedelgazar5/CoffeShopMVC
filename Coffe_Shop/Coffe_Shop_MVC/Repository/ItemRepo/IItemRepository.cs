using Coffe_Shop_MVC.Models;

namespace Coffe_Shop_MVC.Repository.ItemRepo
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item GetById(int id);
        void Add(Item item);
        void Update(Item item);
        void Delete(int id);
        void Save();
    }
}