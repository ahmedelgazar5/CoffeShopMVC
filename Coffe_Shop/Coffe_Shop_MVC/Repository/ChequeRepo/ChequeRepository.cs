using Coffe_Shop_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffe_Shop_MVC.Repository.ChequeRepo
{
    public class ChequeRepository : IChequeRepository
    {
        CoffeContext context;
        public ChequeRepository(CoffeContext context)
        {
            this.context = context;
        }
        public List<Cheque> GetAll()
        {
            return context.Cheques.Where(c => c.IsDeleted == false).Include(c=>c.Table).ToList();
        }
        public Cheque GetById(int id)
        {
            return context.Cheques.FirstOrDefault(c => c.Id == id && c.IsDeleted == false);
        }

        public void Add(Cheque cheque)
        {
            context.Cheques.Add(cheque);

        }
        public void Update(Cheque cheque)
        {
            context.Cheques.Update(cheque);

        }
        public void Delete(int id)
        {
            var cheque = context.Cheques.FirstOrDefault(c => c.Id == id);
            cheque.IsDeleted = true;

        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
