using Coffe_Shop_MVC.Models;
namespace Coffe_Shop_MVC.Repository.TableRepo
{
    public class TableRepository:ITableRepository
    {
        CoffeContext _context;
        public TableRepository(CoffeContext _context)
        {
            this._context = _context;

        }
        public List<Table> GetAll()
        {
            return _context.Tables.ToList();
        }
        public Table GetById(int id)
        {
            return _context.Tables.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Table table)
        {
            _context.Tables.Add(table);
            Save();
        }
        public void Update(Table table)
        {
            _context.Tables.Update(table);
            Save();
        }
        public void Delete(Table table)
        {
            _context.Tables.Remove(table);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
