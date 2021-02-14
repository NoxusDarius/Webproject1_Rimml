using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vogt_Aufgabe_1_Rimml.Models
{
    public enum Payment
    {
        CreditCard, DebitCard, Lastname, Visa, notSpecified
    }
    public class registration
    {   public int Registration_ID { get; set; }
        public string Benutzer { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public int PLZ { get; set; }
        public string Email { get; set; }
        public string Wohnort { get; set; }
        public Payment Payment { get; set; }


        public registration() : this(0,"", "","", 0, "", "", Payment.notSpecified) { }
        public registration(int registration_id, string Benutzer, string Password, string Password2, int PLZ, string Email, string Wohnort,Payment payment)
        {
            this.Registration_ID = registration_id;
            this.Benutzer = Benutzer;
            this.Password = Password;
            this.Password2 = Password2;
            this.PLZ = PLZ;
            this.Email = Email;
            this.Wohnort = Wohnort;
            this.Payment = payment;
        }
        public override string ToString()
        {
            return this.Benutzer + " " + this.Password + " " + this.Registration_ID;
        }
    }
}

