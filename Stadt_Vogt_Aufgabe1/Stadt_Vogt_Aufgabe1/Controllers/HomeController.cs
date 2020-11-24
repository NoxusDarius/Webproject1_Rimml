using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stadt_Vogt_Aufgabe1.Models;

namespace Stadt_Vogt_Aufgabe1.Controllers
{
    public class HomeController : Controller
    {

       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewYork()
        {
            return View(CreateArticleList());
        }
        private List<Article> CreateArticleList()
        {
            // normalerweise würden die Artikel aus einer DB-Tabelle geladen
            return new List<Article>()
            {
                new Article(1,"NewYork","Empire State Building","Is an old Building",Country.USA),
                new Article(1,"NewYork","Statue of Liberty","Oct. 1886",Country.USA),
                new Article(1,"NewYork","Ground Zero","Memorial to the WTC",Country.USA),
                new Article(1,"NewYork","Central Park","A beatiful place to chill and relax",Country.USA),
            };
        }
        public IActionResult LosAngeles()
        {
            return View(CreateArticleList2());
        }
        private List<Article> CreateArticleList2()
        {
            // normalerweise würden die Artikel aus einer DB-Tabelle geladen
            return new List<Article>()
            {
                new Article(1,"Los Angeles","Griffith Observatorium","A beatiful view at top of the building",Country.USA),
                new Article(1,"Los Angeles","Hollywood Walk of Fame","U can meet the top of the world",Country.USA),
                new Article(1,"Los Angeles","Long Beach","U can go swim there",Country.USA),
                new Article(1,"Los Angeles","Disneyland","A place for childreen and parents",Country.USA),
            };
        }

    }   
}
