using Coffe_Shop_MVC.Models;
using Coffe_Shop_MVC.Repository.CategoryRepo;
using Coffe_Shop_MVC.Repository.OrderRepo;
using Coffe_Shop_MVC.Repository.TableRepo;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Coffe_Shop_MVC.Controllers
{
    public class TableController : Controller
    {
        ITableRepository _tableRepository;
        public TableController(ITableRepository _tableRepository)
        {
            this._tableRepository = _tableRepository;
        }

        public IActionResult Index()
        {
            List<Table> tables = _tableRepository.GetAll();
            return View(tables);
        }
        public IActionResult Details(int id)
        {
            Table table = _tableRepository.GetById(id);
            return View(table);
        }
        public IActionResult Edit(int id)
        {
            Table table = _tableRepository.GetById(id);
            return View( table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Table table) //Check Server Side
        {
            if (ModelState.IsValid == true)
            {
                _tableRepository.Update(table);
                _tableRepository.Save();
                return RedirectToAction("Index");
            }
            return View(table);
        }

        public IActionResult Delete(int id)
        {
            Table table = _tableRepository.GetById(id);
            _tableRepository.Delete(table);
            _tableRepository.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            _tableRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Table table)
        {
            if (ModelState.IsValid == true) //Check Server Side
            {
                _tableRepository.Add(table);
                _tableRepository.Save();
                return RedirectToAction("Index");
            }
            _tableRepository.GetAll();
            return View(table);
        }

    }
}
