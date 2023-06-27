using Coffe_Shop_MVC.Models;

namespace Coffe_Shop_MVC.Repository.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        CoffeContext context;
        public CategoryRepository(CoffeContext context) 
        {
            this.context = context;
        }
        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }
        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id); 
        }

        public void Add(Category category)
        {
            context.Categories.Add(category);
            Save();
        }
        public void Update(Category category)
        {
            context.Categories.Update(category);
            Save();
        }
        public void Delete(Category category)
        {
            context.Categories.Remove(category);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
