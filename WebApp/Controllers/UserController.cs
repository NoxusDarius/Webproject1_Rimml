using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApp.Models;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View(new WebApp.Models.Person());
        }
        [HttpPost]
        public ActionResult Register(Person personDataFromForm)
        {
            //Formulardatn (personDataFromForm) überprüfen 

            // Falls die Personen Daten nicht richtig sinnd erfolgt formular erneut anzeigen 

            // Falls die Personen Daten Richtig sind abspeichern und Meldung anzeigen

            //z.B: die Personendaten in einer DB-Tabelle abspeichern (nächstes Jahr) 
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new Login());
        }
        [HttpPost]
        public ActionResult Login(Login LoginData)
        {
            return View();
        }

    }
}