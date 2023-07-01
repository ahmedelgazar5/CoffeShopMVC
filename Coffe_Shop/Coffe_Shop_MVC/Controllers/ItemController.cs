using Coffe_Shop_MVC.Models;
using Coffe_Shop_MVC.Repository.CategoryRepo;
using Coffe_Shop_MVC.Repository.ItemRepo;
using Microsoft.AspNetCore.Mvc;

namespace Coffe_Shop_MVC.Controllers
{
    public class ItemController : Controller
    {
        IItemRepository itemRepository;
        ICategoryRepository categoryRepository;
        public ItemController(IItemRepository itemRepository , ICategoryRepository categoryRepository)
        {
            this.itemRepository = itemRepository;
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Item> items = itemRepository.GetAll();
            return View(items);
        }
        public IActionResult Details(int id)
        {
            Item item = itemRepository.GetById(id);  
            return View(item);
        }
        [HttpGet]
        public IActionResult Add() 
        {
            ViewBag.Categories = categoryRepository.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Item item)
        {
            itemRepository.Add(item);
            itemRepository.Save();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Item item = itemRepository.GetById(id);
            ViewBag.Categories = categoryRepository.GetAll();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            itemRepository.Update(item);
            itemRepository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            itemRepository.Delete(id);
            itemRepository.Save();
            return RedirectToAction("Index");
        }


    }
}
