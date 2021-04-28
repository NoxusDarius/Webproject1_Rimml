using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBsp_Einführung.Controllers
{
    public class javascriptuebung : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
