using Coffe_Shop_MVC.Models; 

namespace Coffe_Shop_MVC.Repository.CategoryRepo
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        void Save();
    }
}