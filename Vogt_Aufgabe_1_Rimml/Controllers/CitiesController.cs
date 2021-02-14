using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vogt_Aufgabe_1_Rimml.Controllers
{
    public class CitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
