using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRPractice.Models;
using SignalRPractice.Service;
using System.Diagnostics;

namespace SignalRPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserService _user = new UserService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("userName");
            if (String.IsNullOrEmpty(userName))
            {
                return Redirect("/Home/Login");
            }
            ViewBag.UserName = userName;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userName");
            Response.Cookies.Delete("userName");
            return Redirect("/Home/Login");
        }
        public IActionResult Submit(string name , string password)
        {
            UserInfo userInfo = _user.GetUser(name, password);
            if (string.IsNullOrEmpty(userInfo.ID))
            {
                return Redirect("/Home/Error");
            }
            HttpContext.Session.SetString("userName" , userInfo.Name);
            Response.Cookies.Append("userName", userInfo.Name);
            return Redirect("/");
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