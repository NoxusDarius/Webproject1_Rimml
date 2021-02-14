using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vogt_Aufgabe_1_Rimml.Models
{
    public class login
    {
        public string Benutzer { get; set; }
        public string Password { get; set; }

        public login() : this("", "") { }
        public login(string Benutzer, string Password)
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

