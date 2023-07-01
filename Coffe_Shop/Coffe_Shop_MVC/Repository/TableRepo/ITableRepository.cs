using Coffe_Shop_MVC.Models;
namespace Coffe_Shop_MVC.Repository.TableRepo
{
    public interface ITableRepository
    {
        List<Table> GetAll();
        Table GetById(int id);
        void Add(Table table);
        void Update(Table table);
        void Delete(Table table);
        void Save();
    }
}
