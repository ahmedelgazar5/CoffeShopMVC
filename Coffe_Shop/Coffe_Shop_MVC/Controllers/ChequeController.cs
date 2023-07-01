using Coffe_Shop_MVC.Models;
using Coffe_Shop_MVC.Repository.CategoryRepo;
using Coffe_Shop_MVC.Repository.ChequeRepo;
using Microsoft.AspNetCore.Mvc;

namespace Coffe_Shop_MVC.Controllers
{
    public class ChequeController : Controller
    {
        IChequeRepository chequeRepository;
        CoffeContext context;
        public ChequeController(IChequeRepository chequeRepository,CoffeContext context)
        {
            this.context = context;
            this.chequeRepository = chequeRepository;
        }
        public IActionResult Index()
        {
            List<Cheque> cheques = chequeRepository.GetAll();
            return View(cheques);
        }
        public IActionResult Details(int id)
        {
            Cheque cheque = chequeRepository.GetById(id);
            return View(cheque);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.tables = context.Tables.ToList();
            Cheque cheque = chequeRepository.GetById(id);
            return View(cheque);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cheque cheque)
        {
            chequeRepository.Update(cheque);
            chequeRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.tables=context.Tables.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Cheque cheque)
        {
            chequeRepository.Add(cheque);
            chequeRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            
            chequeRepository.Delete(id);
            chequeRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
