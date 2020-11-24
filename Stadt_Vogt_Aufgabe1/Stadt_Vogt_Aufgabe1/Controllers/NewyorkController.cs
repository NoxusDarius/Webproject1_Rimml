using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stadt_Vogt_Aufgabe1.Models;

namespace Stadt_Vogt_Aufgabe1.Controllers
{
    public class NewyorkController : Controller
    {
        public IActionResult Index()
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
    }
}
