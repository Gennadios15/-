using ImportData;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public IActionResult GETCalendars()
        {
            DBConnection dbConnection = new DBConnection();
            var data = dbConnection.FetchData();

            // Pass the data to the view or process it as needed
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}