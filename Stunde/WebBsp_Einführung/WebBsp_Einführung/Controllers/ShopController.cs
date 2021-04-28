using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBsp_Einführung.Models;
using WebBsp_Einführung.Models.DB;


namespace WebBsp_Einführung.Controllers
{
    public class ShopController : Controller
    {
        // links Interface; rechts Klasse
        private IRepositoryArticles rep = new RepositoryArticlesDB();
        public IActionResult Index()
        {
            //normalerweise würden alle Artikel aus einer DB-Tabelle geladen
            return View(CreateArticleList());
        }
        public IActionResult Refund()
        {
            //normalerweise würden alle Artikel aus einer DB-Tabelle geladen
            
            return View();
        }
        // HttpGet ... diese Methode wird aufgerufen, wenn ein Link angeklickt wird
        [HttpGet]
        public IActionResult createNewArticle()
        {
            // die zugehörige View (Eingabeformular für die Artikeldaten) wird mit einem leeren Artikel aufgerufen
            return View(new Article());
        }
        // HttpPost ... diese Methode wird aufgerufen, wenn das zugehörige Formular abgesendet wird
        [HttpPost]
        public IActionResult createNewArticle(Article newArticle)
        {
            // Parameter überprüfen
            if(newArticle == null)
            {
                return RedirectToAction("CreateNewArticle");
            }
            //Eingaben des Benutzers auf Richtigkeit überprüfen
            ValidateArticleData(newArticle);
            // => Eingabe ok -> Daten werden in einer DB-Tabelle abgespeichert
            if (ModelState.IsValid)
            {
                //Artikeldaten z.B. in der DB-Tabelle abspeichern
                //DB-Verbindung öffnen
                rep.Open();

                //Daten in der DB-Tabelle abspeichern
                if (rep.Insert(newArticle))
                {
                    rep.Close();
                    return RedirectToAction("Index", "Shop");
                }
                //DB-Verbindung schließen
                rep.Close();

                //TODO: normalerweise eine entsprechende Meldung anzeigen
                //Alternative: Redirect zu Home/Index
                return RedirectToAction("Index", "Home");
            }
            // => Eingabe nicht ok ->  Formular mit den alten Daten erneut anzeigen inkl. Fehlermeldungen


            return View(newArticle);
        }
        //in dieser Methode wird die Eingabe des Benutzers auf richtigkeit überprüft
        private void ValidateArticleData(Article a)
        {
            //Parameter überprüfen
            if(a == null)
            {
                return;
            }
            //Artikelname überprüfen - Vorgabe: min. 3 Zeichen lang
            if(a.ArticleName == null || a.ArticleName.Length < 3)
            {
                //                      Name des Feldes in der Klasse | anzuzeigende Fehlermeldung
                ModelState.AddModelError(nameof(Article.ArticleName), "Der Artikelname muss mind. 3 Zeichen lang sein!");
            }
            //Preis: muss positiv oder 0 sein
            if(a.Price < 0.0m)
            {
                ModelState.AddModelError(nameof(Article.Price), "Der Preis muss positiv oder 0 sein");
            }
            if(a.ReleaseDate < new DateTime(1900, 1, 1))
            {
                ModelState.AddModelError(nameof(Article.ReleaseDate), "Bitte geben Sie ein vernünftiges Datum ein!");
            }
            if (a.Category.Equals(Category.notSpecified))
            {
                ModelState.AddModelError(nameof(Article.Category), "Keine Kategorie angegeben");
            }
        }

        private List<Article> CreateArticleList()
        {
            return new List<Article>()
            {
                new Article(1, "iPhone 11", "Apple", new DateTime(2020, 3, 18), 999.90m, Category.Handies),
                new Article(2, "Acer Aspire", "Acer", new DateTime(2015, 1, 5), 499.90m, Category.Laptops),
                new Article(3, "Maus XY", "Razer", new DateTime(2019, 1, 12), 19.90m, Category.Technigs),
                new Article(4, "ASP.NET MVC", "Apres", new DateTime(2020, 10, 1), 49.90m, Category.Books)
            };
        }
    }
}
