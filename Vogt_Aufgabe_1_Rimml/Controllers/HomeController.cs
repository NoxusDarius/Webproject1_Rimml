using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vogt_Aufgabe_1_Rimml.Models;

namespace Vogt_Aufgabe_1_Rimml.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        { return View();
        }
    }
}
