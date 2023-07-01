using Coffe_Shop_MVC.Models;
using Coffe_Shop_MVC.Repository.CategoryRepo;
using Microsoft.AspNetCore.Mvc;

namespace Coffe_Shop_MVC.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository categoryRepository;    
        public CategoryController(ICategoryRepository categoryRepository) 
        {
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.GetAll();
            return View(categories);
        }
        public IActionResult Details(int id) 
        {
           Category category=  categoryRepository.GetById(id);
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = categoryRepository.GetById(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            categoryRepository.Update(category);
            categoryRepository.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
             return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Category category)
        {
            categoryRepository.Add(category);
            categoryRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete (int id)
        {
            //Category category = categoryRepository.GetById(id);
            categoryRepository.Delete(id);
            categoryRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
