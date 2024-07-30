using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;



        
        public HomeController( ApplicationDbContext context)
        {
            _context = context;
        }
            
       
        public IActionResult AddNewItems() {

            ViewBag.Username = HttpContext.Session.GetString("userdata");


            return  View();
        }

        [Authorize]
        public IActionResult Index()
        {
            var username = HttpContext.User.Identity.Name ?? null;  // get user data

            //TempData["userdata"]=username;
            CookieOptions cookie = new CookieOptions(); // create  cookie
            cookie.Expires = DateTime.Now.AddMinutes(50); // set time long
            Response.Cookies.Append("userdata", username, cookie); // store user data in my cookie


            HttpContext.Session.SetString("userdata", username);

            ViewBag.Username = username;

            ViewBag.Username = Request.Cookies["userdata"]; // get user data from my cookie

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
