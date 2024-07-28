using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using System.Diagnostics;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;

        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShoppingCartClass()
        {
            var allItems = _context.ShoppingCartDb.ToList();
            var totalExpenses = allItems.Sum(x => x.numItems * x.cost);
            ViewBag.ShoppingCartClass = totalExpenses;
            return View(allItems);
        }
        public IActionResult CreateEditCart(int? id) 
        {
            if (id != null)
            {
                var itemInDb = _context.ShoppingCartDb.SingleOrDefault(x => x.Id == id);
                return View(itemInDb);
            }
            return View();
        }
        public IActionResult DeleteItem(int id)
        {
            var itemInDb = _context.ShoppingCartDb.SingleOrDefault(x => x.Id == id);
            _context.ShoppingCartDb.Remove(itemInDb);   
            _context.SaveChanges(); 
            return RedirectToAction("ShoppingCartClass");
        }
        public IActionResult CreateEditCartForm(ShoppingCartClass model)
        {
            if (model.Id == 0)
            {
                _context.ShoppingCartDb.Add(model);
            }
            else
            {
                _context.ShoppingCartDb.Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("ShoppingCartClass");   
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
