using Lernen_Vogt_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;



namespace Lernen_Vogt_Test.Controllers
{
    public class HomeController : Controller
    {
        IArticleDB rep = new ArticleDB();
       public IActionResult Index()
        {   
            return View();
        }
        public IActionResult Lernen()
        {
            try
            {
                rep.Open();
                return View(rep.GetAllArticles());
            }
            catch (Exception ex)
            {
                return View("Message", new Message("Datenbank Fehler", ex.Message));
            }
            finally
            {
                rep.Close();
            }
        }
        public IActionResult Formular2()
        {
            return View();
        }

        public IActionResult GetArticleByID(int article_ID)
        {
            try
            {
                rep.Open();
                return View(rep.GetArticleById(article_ID));
            }
            catch (Exception ex)
            {
                return View("Message", ex.Message);

            }
            finally
            {
                rep.Close();
            }
        }

        [HttpGet]
        public IActionResult Formular()
        {
            return View(new Article());
        }
        [HttpPost]
        public IActionResult Formular(Article article)
        {
            if (article == null)
            {
                return RedirectToAction("Formular");
            }

            ValidateArticleData(article);
            if (ModelState.IsValid)
            {

                try
                {
                    // Daten in DB-Tabelle eintragen
                    // DB-Verbindung öffnen
                    rep.Open();

                    // Artikeldaten in die DB-Tabelle eintragen
                    if (rep.Insert(article))
                    {
                        // Erfolgsmeldung ausgeben
                        return View("Message", new Message("Datenbank", " Der Artikel wurde erfolgreich abgeschpeichert"));
                    }

                }
                catch (DbException)
                {
                    // Fehlermeldung ausgeben
                    return View("Message", new Message("Der Artikel konnte nicht abgespeichert werden", "Fehler in der Datenbank", "Probieren Sie es später erneut"));
                }
                finally
                {
                    // DB-Verbindung schließen
                    rep.Close();
                }
                return RedirectToAction("index", "home");
            }
            return View("Formular");
        }
       
        public IActionResult Update()
        {
            try
            {
                rep.Open();
                return View(rep.GetAllArticles());
            }
            catch
            {
                throw new Exception("Datenbank fehler");
            }
            finally
            {
                rep.Close();
            }
          
        }
        public IActionResult Excecute(int article_ID, Article newArticle)
        {
            try
            {
                rep.Open();
                rep.Update(article_ID, newArticle);
                return View(rep.GetAllArticles());
            }
            catch
            {
                throw new Exception("Datenbank fehler");
            }
            finally
            {
                rep.Close();
            }
        }
        public IActionResult Delete(int article_ID)
        {
            try
            {
                rep.Open();
                rep.Delete(article_ID);
                return View(rep.GetAllArticles());
            }
            catch
            {
                throw new Exception("Datenbank fehler");
            }
            finally
            {
                rep.Close();
            }
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
            a.name = a.name ?? "";

            // der Artikelname muss mind. 3 Zeichen lang sein
            if (a.name.Length < 3)
            {
                //                          Name des Feldes             die anzuzeigende Fehlermeldung
                ModelState.AddModelError(nameof(Article.name), "Artikelname muss mind. 3 Zeichen lang sein!");
            }
            

            a.beschreibung = a.beschreibung ?? "";
            if (a.beschreibung.Length < 5)
            {
                ModelState.AddModelError(nameof(Article.beschreibung), "Die Descrition muss mind. 5 Zeichen lang sein!");
            }
        }
    }
    }
    

