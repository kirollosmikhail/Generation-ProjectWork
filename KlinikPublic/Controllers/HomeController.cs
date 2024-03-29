using KlinikPublic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KlinikPublic.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult DiconoDiNoi()
        {
            return View();
        }
        public IActionResult Contatti()
        {
            return View();
        }
        public IActionResult DoveSiamo()
        {
            return View();
        }
        public IActionResult ChiSiamo()
        {
            return View();
        }
        public IActionResult Cookies()
        {
            return View();
        }
        public IActionResult ComeFunziona()
        {
            return View();
        }

        public IActionResult Login()
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
