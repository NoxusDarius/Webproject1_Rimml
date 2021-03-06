﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vogt_Aufgabe_1_Rimml.Models;

using System.Data.Common;


namespace Vogt_Aufgabe_1_Rimml.Controllers
{
    public class ShopController : Controller
    {
        IRepositoryArticle rep = new RepositoryArticle();
        public IActionResult Index()
        {
            try
            {
                rep.Open();
                return View(rep.GetAllArticles());
            }
            catch (Exception ex)
            {
                return View("Message", new Message("Datenbakfehler", ex.Message));
            }
            finally
            {
                rep.Close();
            }
        }
        /* private List<Article> CreateArticleList()
         {
             return new List<Article>()
             {
                 new Article(1,"Trip to New York", "Incl. FLight, 5 Star Hotel",3450),
                 new Article(2,"Trip to Los Angeles", "Incl. FLight, 5 Star Hotel",5200.76),
                 new Article(3,"Trip to Innsbruck", "Incl. FLight, 5 Star Hotel",1600.90),
                 new Article(4,"Trip to Spain", "Incl. FLight, 5 Star Hotel",2550),
             };*/
        [HttpGet]
        public IActionResult CreateNewArticle()
        {
          
            return View(new Article());
        }

        [HttpPost]
        public IActionResult CreateNewArticle(Article newArticle)
        {
            if (newArticle == null)
            {
                return RedirectToAction("createNewArticle");
            }

            ValidateArticleData(newArticle);

         
            if (ModelState.IsValid)
            {

                try
                {
               
                    rep.Open();

                   
                    if (rep.Insert(newArticle))
                    {
                       
                        return View("Message", new Message("Datenbank-Erfolgt",
                            "Der Artikel wurde erfolgreich abgespeichert!"));
                    }

                }
                catch (DbException)
                {
                    
                    return View("Message", new Message("Datenbank-Fehler",
                        "Der Artikel konnte nicht abgespeichert werden!",
                        "Probieren Sie es bitte später erneut!"));
                }
                finally
                {
                   
                    rep.Close();
                }


            
                return RedirectToAction("index", "home");
            }

            
            return View(newArticle);
        }

        private void ValidateArticleData(Article a)
        {
            if (a == null)
            {
                return;
            }

            // if (a.Articlename == null) {
            //      a.Articlename = "";
            // }
            a.Name = a.Name ?? "";

         
            if (a.Name.Length < 3)
            {
              
                ModelState.AddModelError(nameof(Article.Name), "Artikelname muss mind. 3 Zeichen lang sein!");
            }
            if (a.Price < 0.0)
            {
                ModelState.AddModelError(nameof(Article.Price), "Der Artikelpreis muss positiv sein!");
            }

            a.Description = a.Description ?? "";
            if (a.Description.Length < 5)
            {
                ModelState.AddModelError(nameof(Article.Description), "Die Descrition muss mind. 5 Zeichen lang sein!");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                rep.Open();

                if (rep.Delete(id))
                {
                    return View("Message", new Message("Datebank", "Der Artikel wurde gelöscht!"));
                }
                else
                {
                    return View("Message", new Message("Datebank", "Der Artikel konnte nicht gelöscht werden!"));
                }
            }
            catch (Exception ex)
            {
                return View("Message", new Message("Datenbakfehler", ex.Message));
            }
            finally
            {
                rep.Close();
            }
        }
    }
}

