using ASp_Yank.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASp_Yank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Hello world Unit-tests !";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "О техникуме";
            return View();
        }
        public IActionResult City()
        {
            return View();
        }
        public IActionResult Cityy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Контакты";
            return View();
        }
        public IActionResult HtmlString()
        {
            return View();
        }
        public IActionResult TabString()
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