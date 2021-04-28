using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebBsp_Einführung.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Impressum()
        {
            return View();
        }
        // für JS/JQuerry
        public IActionResult javaScriptTesten()
        {
            return View();
        }
    }
}
