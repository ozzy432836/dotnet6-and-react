using Microsoft.AspNetCore.Mvc;
using MVCWithReactAsALib.Models;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System.Diagnostics;

namespace MVCWithReactAsALib.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
            public short?  Price { get; set; }
            public string Id { get; set; }
        }

        public IActionResult Index()
        {


            var products = new List<Product>();

            var name = RandomizerFactory.GetRandomizer(new FieldOptionsTextWords());
            var description = RandomizerFactory.GetRandomizer(new FieldOptionsTextWords());
            var price = RandomizerFactory.GetRandomizer(new FieldOptionsShort());
            var image = RandomizerFactory.GetRandomizer(new FieldOptionsTextLipsum());
            

            for (var i = 0; i < 10; i++)
            {
                products.Add(new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name.Generate(),
                    Description = description.Generate(),
                    Price = price.Generate(),
                    Image = image.Generate()
                }); ;
            }

            return View(products);
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