using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stadt_Vogt_Aufgabe1.Models
{
    public class SiteRegistration
    {
        public string Benutzer { get; set; }
        public string Password { get; set; }
        public int PLZ { get; set; }
        public string Email { get; set; }
        public string Wohnort { get; set; }
        

        public SiteRegistration() : this("", "",0,"","") { }
        public SiteRegistration(string Benutzer, string Password, int PLZ, string Email, string Wohnort)
        {   
            this.Benutzer = Benutzer;
            this.Password = Password;
            this.PLZ = PLZ;
            this.Email = Email;
            this.Wohnort = Wohnort;
        }
        public override string ToString()
        {
            return this.Benutzer + " " + this.Password;
        }
    }
}
