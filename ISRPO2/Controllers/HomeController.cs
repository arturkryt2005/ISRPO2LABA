using ISRPO2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISRPO2.Controllers
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

        public IActionResult TaskFirst()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateAge(int birthYear, int birthMonth, int birthDay)
        {

            DateTime currentDate = DateTime.Now; 
            int age = CalculateAgee(birthYear, birthMonth, birthDay, currentDate.Year, currentDate.Month, currentDate.Day);
            ViewData["Age"] = age;
            return View("TaskFirst");
        }

        private int CalculateAgee(int birthYear, int birthMonth, int birthDay, int currentYear, int currentMonth, int currentDay)
        {
            DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);
            int age = currentYear - birthYear;

            if (currentMonth < birthMonth || (currentMonth == birthMonth && currentDay < birthDay))
            {
                age--;
            }

            return age;
        }
        public IActionResult TaskSecond()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckBishopMove(int x1, int y1, int x2, int y2)
        {
            bool canMove = CanBishopMove(x1, y1, x2, y2);
            ViewData["CanMove"] = canMove;
            return View("TaskSecond");
        }

        private bool CanBishopMove(int x1, int y1, int x2, int y2)
        {
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            return dx == dy;
        }
        public IActionResult TaskThird()
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
