using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShorterExample.Models;

namespace UrlShorterExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger  
            )
        {
            _logger = logger; 
        }

        public IActionResult Index(int? id)
        {
            Random random = new Random();
            ShortLink shortLink = new ShortLink();
            if (id.HasValue)
                shortLink.Id = id.Value;
            else
                shortLink.Id = random.Next(0, 100);

            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.ShortLink = shortLink.GetUrlChunk();
            indexViewModel.Id = shortLink.Id;
            indexViewModel.NextId = random.Next(0, 100);
            indexViewModel.Id = shortLink.GetId(indexViewModel.ShortLink);
            return View(indexViewModel);
        }

        public IActionResult DecodeUrl(string id)
        {
            Random random = new Random();
            ShortLink shortLink = new ShortLink();
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Id = shortLink.GetId(id);
            indexViewModel.NextId = random.Next(0, 100);
            return View(indexViewModel);
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