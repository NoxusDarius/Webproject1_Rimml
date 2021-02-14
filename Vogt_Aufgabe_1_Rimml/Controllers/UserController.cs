using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Vogt_Aufgabe_1_Rimml.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace Vogt_Aufgabe_1_Rimml.Controllers
{
    public class UserController : Controller
    {
        MySqlConnection con = new MySqlConnection();
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new login());
        }
        
        [HttpPost]
        void connectionString() {
             con.ConnectionString = "server=localhost;database=db_Accounts;user=root;pwd=Airbase11";
               
        }
        public IActionResult Login(login login)
        {
            login.Password = login.Password + "1234";
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Accounts where benutzer='"+login.Benutzer+"' and password='"+login.Password+"'";
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                if (login.Benutzer == "admin")
                {
                    return View("SuccesfullAdmin");
                    con.Close();
                }
                else
                {
                    return View("Succesfull");
                    con.Close();
                }
               
            }
            else
            {
                return View("Failed");
                con.Close();
            }
            


            


        }


        //Registration
        IRepositoryAccount rep = new RepositoryAccount();

      

        [HttpGet]
        public IActionResult Registration()
        {
            return View(new registration());
        }
        [HttpPost]
        public IActionResult Registration(registration registration)
        {

            registration.Password = registration.Password + "1234";
            registration.Password2 = registration.Password2 + "1234";
            if (registration == null)
            {
                return View(new registration());
            }



            ValidateRegistrationData(registration);

            if (ModelState.IsValid)
            {
                try
                {
                    rep.Open();


                    if (rep.Insert(registration))
                    {
                        return View("Message", new Message("Datenbank-Erfolg", "Der Account wurde Erfolgreich erstellt und abgespeichert!"));
                    }

                }
                catch (DbException)
                {
                    return View("Message", new Message("Datenbank-Fehler",
                    "Der Account konnte nicht erstellt werden!",
                    "Probieren Sie es bitte später erneut!"));
                }
                finally
                {
                    rep.Close();
                }
                return RedirectToAction("index", "home");
            }
            return View(registration);

        }


        private void ValidateRegistrationData(registration r)
        {
            if (r == null)
            {
                return;
            }

            r.Benutzer = r.Benutzer ?? "";
            if (r.Benutzer.Length <= 4)
            {
                ModelState.AddModelError(nameof(registration.Benutzer), "Der Name muss länger als 3 Zeichen sein!");
            }
            r.Password = r.Password ?? "";
            if (r.Password.Length < 6)
            {
                ModelState.AddModelError(nameof(registration.Password), "Das Passwort muss länger als 3 Zeichen sein");
            }
            r.Password = r.Password ?? "";
            if(r.Password != r.Password2)
            {
                ModelState.AddModelError(nameof(registration.Password), "Die Passwörter müssen übereinstimmen!");
            }

        }

    }
}
