using Coding_Test_Makonis.Models;
using Makonis.Common.Models;
using Makonis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Coding_Test_Makonis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IJsonFileSaveService _fileSaverService;
        public HomeController(ILogger<HomeController> logger, IJsonFileSaveService fileSaverService)
        {
            _logger = logger;
            _fileSaverService = fileSaverService;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User userDetails)
        {
            string path = string.Empty;
            if (IsValidUser(userDetails))
            {
                 path = _fileSaverService.SaveUserDetailsToFile(userDetails);
            }
            ViewBag.path = path;
            return View();
        }
        private bool IsValidUser(User user)
        {
            if (user != null && !string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
                return true;

            return false;
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
