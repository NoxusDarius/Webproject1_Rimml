using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stadt_Vogt_Aufgabe1.Models
{
    public class Login
    {
          
        public string Benutzer { get; set; }
        public string Password { get; set; }

        public Login() : this("", "") { }
        public Login(string Benutzer, string Password)
        {
            this.Benutzer = Benutzer;
            this.Password = Password;
        }
        public override string ToString()
        {
            return this.Benutzer + " " + this.Password;
        }
    }
}
