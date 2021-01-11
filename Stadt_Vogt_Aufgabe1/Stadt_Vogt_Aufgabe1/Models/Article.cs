using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stadt_Vogt_Aufgabe1.Models
{
    public enum Country
    {
        AT, USA, ML, AS, notSpecified
    }
    public class Article
    {
        public int CityId { get; set; }
        public string Cityname { get; set; }
        public string Sightseeing { get; set; }
        public string Description { get; set; }
        
        public Country Country { get; set; }

      
        public Article() : this(0, "", "", "",Country.notSpecified) { }
        public Article(int cityid, string cityname, string sightseeing,
            string description, Country country)
        {
            this.CityId = cityid;
            this.Cityname = cityname;
            this.Sightseeing = sightseeing;
            this.Description = description;
            this.Country = country;
        }

       
        public override string ToString()
        {
            return this.CityId + " " + this.Cityname + " " + this.Sightseeing;
        }
    }
}

    

