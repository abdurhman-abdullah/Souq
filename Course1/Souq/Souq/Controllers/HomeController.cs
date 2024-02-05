using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Souq.Models;
using System.Diagnostics;

namespace Souq.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        SouqcomContext db = new SouqcomContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            indexVm result = new indexVm();

            result.Categories = db.Categories.ToList();
            result.Products = db.Products.ToList();
            result.Reviews = db.Reviews.ToList();
            result.LatestProducts = db.Products.OrderByDescending(x => x.EntryDate).Take(4).ToList();
            foreach (var item in result.Products)
            {
                result.productImages.Add(db.ProductImages.Include(i => i.Product).FirstOrDefault(i => i.ProductId == item.Id));
            }
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Categories()
        {
            var cats = db.Categories.ToList();
            return View(cats);
        }

        public IActionResult Products(int id)
        {
            var products = db.Products.Where(x => x.Catid == id).ToList();
            return View(products);
        }

        public IActionResult ProductsDescription(int id)
        {
            var product = db.Products.Include(x => x.Cat).Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult productsSearch(string xName)
        {
            var products = new List<Product>();

            if (string.IsNullOrEmpty(xName))
                products = db.Products.ToList();
            else
            products =  db.Products.Where(x => x.Name.Contains(xName)).ToList();

            return View(products);
        }

        [HttpPost]
        public IActionResult sendReview(Review model)
        {
            db.Reviews.Add(new Review { Name = model.Name, Email = model.Email, Subject = model.Subject, Description = model.Description });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}