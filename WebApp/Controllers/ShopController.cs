using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return View(CreateArticleList());
        }
        private List<Article> CreateArticleList()
        {
            return new List<Article>()
        {
            new Article(1,"IPhone 11","Apple", new DateTime(2020,3,18), 999.90m,"Handy"),
            new Article(2,"Acer Aspire","Acer", new DateTime(2015,1,5), 499.90m,"Laptop"),
            new Article(3,"Maus XY","Razer", new DateTime(2019,12,14), 99.90m,"Elektrogerät"),
            new Article(4,"ASP.NET MVC","Apres", new DateTime(2020,10,1), 19.90m,"Buch"),

        };

        }
    }
}
    