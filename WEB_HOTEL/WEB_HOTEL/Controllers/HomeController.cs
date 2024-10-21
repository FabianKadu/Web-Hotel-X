using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEB_HOTEL.Models;

namespace WEB_HOTEL.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}