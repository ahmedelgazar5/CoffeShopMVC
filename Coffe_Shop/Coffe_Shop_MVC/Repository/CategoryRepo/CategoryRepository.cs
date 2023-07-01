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
            return context.Categories.Where(c=>c.IsDeleted==false).ToList();
        }
        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id && c.IsDeleted == false); 
        }

        public void Add(Category category)
        {
            context.Categories.Add(category);
         
        }
        public void Update(Category category)
        {
            context.Categories.Update(category);
    
        }
        public void Delete(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            category.IsDeleted = true;
  
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
