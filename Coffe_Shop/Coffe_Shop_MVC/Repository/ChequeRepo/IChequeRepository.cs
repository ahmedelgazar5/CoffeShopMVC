using Coffe_Shop_MVC.Models;

namespace Coffe_Shop_MVC.Repository.ChequeRepo
{
    public interface IChequeRepository
    {
        List<Cheque> GetAll();
        Cheque GetById(int id);
        void Add(Cheque cheque);
        void Update(Cheque cheque);
        void Delete(int id);
        void Save();
    }
}