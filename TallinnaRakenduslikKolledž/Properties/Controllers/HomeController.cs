using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
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
            ViewData["Värv"] = "Details";
            return View();

            
        }
        public IActionResult Privacy2()
        {
            ViewData["Värv"] = "Delete";
            return View("Privacy");
        }
        public IActionResult Privacy3()
        {
            ViewData["Värv2"] = "Edit";
            return View();

            
        }public IActionResult Privacy4()
        {
            ViewData["Värv2"] = "Create";
            return View();

            
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
