using Microsoft.AspNetCore.Mvc;
using RentHive.Models;
using System.Diagnostics;

namespace RentHive.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int userId, string userEmail,string userType) 
        {
            ViewBag.Acc_Id = userId;
            ViewBag.Acc_Email = userEmail;
            ViewBag.Acc_UserType = userType;

            return View();
        }
        public IActionResult WelcomePage()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }
        public IActionResult HiveUserVerification()
        {
            return View();
        }
        public IActionResult HiveUserList()
        {
            return View();
        }
        public IActionResult HiveUserlog()
        {
            return View();
        }
        public IActionResult HivePaymentHistory()
        {
            return View();
        }
        public IActionResult RentalServices()
        {
            return View();
        }
        public IActionResult RentalProcessServices()
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