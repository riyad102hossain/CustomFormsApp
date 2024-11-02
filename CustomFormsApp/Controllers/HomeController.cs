using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomFormsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Admin()
        {
            return View();
        }

        //public IActionResult Templates()
        //{
        //    return View();
        //}

        [Authorize(Roles = "RegisteredUser, Admin")]
        public IActionResult User()
        {
            return View();
        }
    }
}
