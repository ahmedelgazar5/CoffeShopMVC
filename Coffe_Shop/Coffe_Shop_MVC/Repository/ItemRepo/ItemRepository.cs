using Coffe_Shop_MVC.Models;

namespace Coffe_Shop_MVC.Repository.ItemRepo
{
    public class ItemRepository : IItemRepository
    {
        CoffeContext context;
        public ItemRepository(CoffeContext context)
        {
            this.context = context;
        }

        public List<Item> GetAll () 
        {
            return context.Items.Where(I=>I.IsDeleted == false).ToList();
        }

        public Item GetById (int id)
        {
            return context.Items.FirstOrDefault(I => I.Id == id && I.IsDeleted == false);
        }

        public void Add (Item item)
        {
            context.Items.Add(item);
            
        }

        public void Update (Item item)
        {
            context.Update(item);
            
        }

        public void Delete (int id)
        {
            Item item = GetById(id);
            item.IsDeleted = true;
            
        }

        public void Save ()
        {
            context.SaveChanges();
        }
    }
}
