using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }

        public Login() : this("", "", "") { }
        public Login(string email, string password, string username)
        {
            
            this.password = password;
            this.username = username;
            this.email = email;

        }
        public override string ToString()
        {
            return this.username + " "  + this.email + "\n";
        }

    }
}