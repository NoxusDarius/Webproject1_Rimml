using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stadt_Vogt_Aufgabe1.Models;

namespace Stadt_Vogt_Aufgabe1.Controllers
{
    public class UserController : Controller
    {
       
        [HttpGet]
        public IActionResult Login()
        {
            return View(new Login());
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (login == null)
            {
                return RedirectToAction("Login");
            }
           /* ValidateLOGINData(login);*/
            if (ModelState.IsValid)
            {
                return RedirectToAction("index", "home");
            }
            return View(login);
        }
       /* private void ValidateLOGINData(Login l)
        {
            if (l == null)
            {
                return;
            }

            l.Benutzer = l.Benutzer ?? "";
            if (l.Benutzer.Length < 3)
            {
                ModelState.AddModelError(nameof(SiteRegistration.Benutzer), "Der Name muss länger als 3 Zeichen sein!");
            }
            l.Password = l.Password ?? "";
            if (l.Password.Length < 3)
            {
                ModelState.AddModelError(nameof(SiteRegistration.Password), "Falsches Passwort!");
            }
        }

        */


















       
        [HttpGet]
        public IActionResult Registration()
        {
            return View(new SiteRegistration());
        }
        [HttpPost]
        public IActionResult Registration(SiteRegistration registration)
        {
            if (registration == null)
            {
                return RedirectToAction("Registration");
            }
            ValidateRegistrationData(registration);
            if (ModelState.IsValid)
            {
                return RedirectToAction("index", "home");
            }
            return View(registration);
        }
        private void ValidateRegistrationData(SiteRegistration r)
        {
            if (r == null)
            {
                return;
            }

            r.Benutzer = r.Benutzer ?? "";
            if (r.Benutzer.Length < 3)
            {
                ModelState.AddModelError(nameof(SiteRegistration.Benutzer), "Der Name muss länger als 3 Zeichen sein!");
            }
            r.Password = r.Password ?? "";
            if (r.Password.Length < 3)
            {
                ModelState.AddModelError(nameof(SiteRegistration.Password), "Das Passwort muss länger als 3 Zeichen sein");
            }
           
        }


        public IActionResult RealIndex()
        {
            return View();
        }
    }
}
