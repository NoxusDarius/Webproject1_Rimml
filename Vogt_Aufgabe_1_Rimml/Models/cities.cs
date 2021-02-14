using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vogt_Aufgabe_1_Rimml.Models
{
    public enum Country
    {
        AT, USA, ML, AS, notSpecified
    }
    public class cities
    {
       
       
            public int CityId { get; set; }
            public string Cityname { get; set; }
            public string Sights { get; set; }
            public string Description { get; set; }

            public Country Country { get; set; }


            public cities() : this(0, "", "", "", Country.notSpecified) { }
            public cities(int cityid, string cityname, string sightseeing,
                string description, Country country)
            {
                this.CityId = cityid;
                this.Cityname = cityname;
                this.Sights = sightseeing;
                this.Description = description;
                this.Country = country;
            }


            public override string ToString()
            {
                return this.CityId + " " + this.Cityname + " " + this.Sights;
            }
        }
    }

