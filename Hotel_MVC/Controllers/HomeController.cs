using Hotel_MVC.Models;
using Hotel_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Hotel_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApartmanService _apartmanService;


        public HomeController(ILogger<HomeController> logger, IApartmanService apartmanService)
        {
            _logger = logger;
            _apartmanService = apartmanService;
        }

        public IActionResult Index()
        {
            var apartmani = _apartmanService.Get();
            return View(apartmani);
        }

        public IActionResult Insert()
        {
            return View();
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