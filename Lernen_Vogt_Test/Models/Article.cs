using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lernen_Vogt_Test.Models
{
    public class Article
    {
        public string name { get; set; }

        public int article_ID { get; set; }
        public string beschreibung { get; set; }
        public double preis { get; set; }

        public Article() : this("",0,"",0.0) { }
        public Article (string Name, int Article_ID, string Beschreibung, double Preis)
        {
            this.name = Name;
            this.article_ID = Article_ID;
            this.beschreibung = Beschreibung;
            this.preis = Preis;
        }

        public override string ToString()
        {
            return this.article_ID + " " + this.name + " " + this.beschreibung + " " + this.preis;
        }

    }
   
}
