using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vogt_Aufgabe_1_Rimml.Models
{
    
    public class Article
    {



        public int Article_ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }

       


        public Article() : this(0, "", "", 0.0) { }
        public Article(int article_ID, string name, string description,
            double price)
        {
            this.Article_ID= article_ID;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            
        }


        public override string ToString()
        {
            return this.Article_ID + " " + this.Name + " " + this.Description + " " + this.Price;
        }
    }
}

