using Google.Apis.Auth.OAuth2;
using ImportData.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Diagnostics;
using UniCalendar.Models;

namespace UniCalendar.Controllers
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

        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Courses()
        {
            return View();
        }

        public IActionResult Professor()
        {
            return View();
        }

        public IActionResult Header()
        {
            return View();
        }

        public IActionResult HeaderLogIn()
        {
            return View();
        }

        public IActionResult Footer()
        {
            return View();
        }

        public IActionResult Index1()
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