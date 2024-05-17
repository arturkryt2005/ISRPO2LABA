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
