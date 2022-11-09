using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using ValidationTest.DAL;
using ValidationTest.Models;

namespace ValidationTest.Controllers
{
    public class HomeController : Controller
    {
        private IUserDALDetails _userDALDetails;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IUserDALDetails userDALDetails)
        {
            _logger = logger;
            _userDALDetails = userDALDetails;   
        }

        public IActionResult Index()
        {
            var userDetails=_userDALDetails.GetUserList();
            ViewBag.Countries=_userDALDetails.GetCountryDetails();
            return View(userDetails);
        }

        [HttpGet]
        public bool CheckEmailExists(string email)
        {
            bool result = _userDALDetails.GetUserList().Any(x=>x.Email==email);
            return result;
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