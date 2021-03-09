using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace Vogt_Aufgabe_1_Rimml.Models
{
    public class RepositoryAccount : IRepositoryAccount
    {
       
        private string _connectionString = "server=localhost;database=db_Accounts;user=root;pwd=Airbase11";

        private MySqlConnection _conn = null;
        

       

        public void Open()
        {
            if (this._conn == null)
            {

                this._conn = new MySqlConnection(this._connectionString);
            }

            if (this._conn.State != ConnectionState.Open)
            {
                this._conn.Open();
            }
        }


        public void Close()
        {

            if ((this._conn != null) && (this._conn.State == ConnectionState.Open))
            {
                this._conn.Close();
            }
        }

      

        public List<registration> GetAllRegistration()
        {

            if (this._conn.State == ConnectionState.Open)
            {
                List<registration> registration = new List<registration>();
                

                DbCommand cmdSelect = this._conn.CreateCommand();

                cmdSelect.CommandText = "select * from articles order by registration_id";

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        registration.Add(new registration
                        {

                            Registration_ID = Convert.ToInt32(reader["registration_ID"]),
                            Benutzer = Convert.ToString(reader["benutzer"]),
                            Password = Convert.ToString(reader["password"]),
                            PLZ = Convert.ToInt32(reader["plz"]),
                            Email = Convert.ToString(reader["email"]),
                            Wohnort = Convert.ToString(reader["wohnort"]),
                            Payment = (Payment)Convert.ToInt32(reader["payment"]),



                        });
                    }

                }

                if (registration.Count == 0)
                {
                    return null;
                }

                return registration;
            }

            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }


        public registration GetAllRegistrationbyID(int registration_ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(registration registration)
        {
            if (registration == null)
            {
                return false;
            }
            if (this._conn.State != ConnectionState.Open)
            {
                return false;
            }


            DbCommand cmdInsert = this._conn.CreateCommand();


            cmdInsert.CommandText = "insert into Accounts values(null, @benutzer, @password, @plz, @email, @wohnort, @payment);";


            DbParameter parambenutzername = cmdInsert.CreateParameter();

            parambenutzername.ParameterName = "benutzer";
            parambenutzername.DbType = DbType.String;
            parambenutzername.Value = registration.Benutzer;

            DbParameter parampassword = cmdInsert.CreateParameter();
            parampassword.ParameterName = "password";
            parampassword.DbType = DbType.String;
            parampassword.Value = registration.Password;

            DbParameter paramplz = cmdInsert.CreateParameter();
            paramplz.ParameterName = "plz";
            paramplz.DbType = DbType.Int32;
            paramplz.Value = registration.PLZ;

            DbParameter paramemail = cmdInsert.CreateParameter();
            paramemail.ParameterName = "email";
            paramemail.DbType = DbType.String;
            paramemail.Value = registration.Email;

            DbParameter paramwohnort = cmdInsert.CreateParameter();
            paramwohnort.ParameterName = "wohnort";
            paramwohnort.DbType = DbType.String;
            paramwohnort.Value = registration.Wohnort;

            DbParameter parampayment = cmdInsert.CreateParameter();
            parampayment.ParameterName = "payment";
            parampayment.DbType = DbType.Int32;
            parampayment.Value = registration.Payment;






            cmdInsert.Parameters.Add(parambenutzername);
            cmdInsert.Parameters.Add(parampassword);
            cmdInsert.Parameters.Add(paramplz);
            cmdInsert.Parameters.Add(paramemail);
            cmdInsert.Parameters.Add(paramwohnort);
            cmdInsert.Parameters.Add(parampayment);


            return cmdInsert.ExecuteNonQuery() == 1;

        }

      
    }

}

