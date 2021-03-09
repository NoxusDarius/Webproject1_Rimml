using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Vogt_Aufgabe_1_Rimml.Models;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace Vogt_Aufgabe_1_Rimml.Controllers
{
    public class UserController : Controller
    {
        public static int id;
       
        MySqlConnection con = new MySqlConnection();
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("login");
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
            login.Password = GetHashCode(login.Password);
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Accounts where benutzer='" + login.Benutzer + "' and password='" + login.Password + "'";
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                if (login.Benutzer == "admin")
                {
                    HttpContext.Session.SetString("login", login.Benutzer);

                    return View("SuccesfullAdmin");
                    con.Close();
                }
                else
                {
                    HttpContext.Session.SetString("login", login.Benutzer);

                    con.Close();
                    con.Open();
                    com.CommandText = "select registration_ID from Accounts where benutzer='" + login.Benutzer + "'";
                    dr = com.ExecuteReader();
                    dr.Read();
                    id = dr.GetInt32(0);
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

        private string GetHashCode(string password)
        {
            throw new NotImplementedException();
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

            registration.Password = GetHashCode(registration.Password);
            registration.Password2 = GetHashCode(registration.Password);





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
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Accounts where benutzer='" + r.Benutzer + "'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                ModelState.AddModelError(nameof(registration.Benutzer), "Is already used");
            }
            else
            {

                return;


            }
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
                if (r.Password != r.Password2)
                {
                    ModelState.AddModelError(nameof(registration.Password), "Die Passwörter müssen übereinstimmen!");
                }

            }

        }
    }
