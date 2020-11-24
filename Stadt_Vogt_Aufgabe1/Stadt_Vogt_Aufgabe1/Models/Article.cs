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

        /*
         int ... Ganzzahlen von ~-2Mrd. bis ~+2Mrd.
         int? ... Ganzzahlen von ~-2Mrd. bis ~+2Mrd. und zusätzlich null
        int? zahl = null;
        double? wert = null;
        */

        // ctors
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

        // ToString() überschreiben
        public override string ToString()
        {
            return this.CityId + " " + this.Cityname + " " + this.Sightseeing;
        }
    }
}

    

