using ImportData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace UniCalendar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnicalendarDbContext _context;

        public HomeController(ILogger<HomeController> logger, UnicalendarDbContext context)
        {
            _logger = logger;
            _context = context;
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

        public IActionResult Footer()
        {
            return View();
        }

        public IActionResult Sign_In()
        {
            return View();
        }

        public IActionResult Sign_Up()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult GETevents()
        {
            return View();
        }

        public IActionResult Course_Info()
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