﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Stadt_Vogt_Aufgabe1.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult newYork()
        {
            return View();
        }
    }
}
