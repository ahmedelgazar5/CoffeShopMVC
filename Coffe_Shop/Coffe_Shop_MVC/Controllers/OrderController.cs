using Coffe_Shop_MVC.Models;
using Coffe_Shop_MVC.Repository.OrderRepo;
using Coffe_Shop_MVC.Repository.TableRepo;
using Microsoft.AspNetCore.Mvc;

namespace Coffe_Shop_MVC.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository orderRepository;
        ITableRepository tableRepository;
        CoffeContext context;
        public OrderController(IOrderRepository orderRepository, ITableRepository tableRepository ,CoffeContext context)
        {
            this.orderRepository = orderRepository;
            this.tableRepository = tableRepository;
            this.context = context;

        }
        public IActionResult Index()
        {
            List<Order> orders = orderRepository.GetAll();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            Order order = orderRepository.GetById(id);
            return View(order);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Tables = tableRepository.GetAll();
            ViewBag.Cheques = context.Cheques.ToList();
            Order order = orderRepository.GetById(id);
            return View (order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order order) //Check Server Side
        {
            if (ModelState.IsValid == true)
            {
                orderRepository.Update(order);
                orderRepository.Save();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public IActionResult Delete(int id)
        {
            Order order = orderRepository.GetById(id);
            orderRepository.Delete(order);
            orderRepository.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            orderRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Order order)
        {
            if (ModelState.IsValid == true) //Check Server Side
            {
                orderRepository.Add(order);
                orderRepository.Save();
                return RedirectToAction("Index");
            }
            orderRepository.GetAll();
            return View(order);
        }
    }
}
