using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Person
    {
        //automatisches Property


        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime birthdate { get; set; }
        public String description { get; set;  }
        public string email { get; set; }
        public string password { get; set; }
        public string password2 { get; set; }
        public int  ID { get; set; }


        //Normales Property 
        private double height;
        
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0.0)
                {
                    this.height = value;
                }
            }
        }
        public Person() : this(0,"","",0.0,DateTime.MinValue,"") { }
        public Person(int ID, string firstname,string lastname, double height,DateTime birth, string email)
        {
            this.ID = ID;
            this.firstname = firstname;
            this.lastname = lastname;
            this.Height = height;
            this.birthdate = birthdate;
            this.email = email;

        }
        public override string ToString()
        {
            return this.firstname+" "+this.lastname+" "+this.email+"\n";
        }

    }
}