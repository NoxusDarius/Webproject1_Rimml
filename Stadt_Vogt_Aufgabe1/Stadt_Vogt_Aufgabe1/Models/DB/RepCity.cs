using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Stadt_Vogt_Aufgabe1.Models.DB
{//Die Datenbank Klasse implementiert das Interface Interface //Namen von Interface ändern 
    // => es müssen alle Methoden ausprogrammiert werden 
    public class RepCity : Interface
    {   //Verbindungszeichenkette 
        private string _connectionString = "server=localhost;database=db_online;uid=root;pwd=Airbase11";
        private MySqlConnection _conn = null;
        public void Close()
        {
            if((this._conn != null) &&( this._conn.State == System.Data.ConnectionState.Open))
            {
                this._conn.Close();
            }
        }

        public bool Delete(int CityID)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetCities()
        {
            throw new NotImplementedException();
        }

        public Article GetCityByID(int CityID)
        {
            throw new NotImplementedException();
        }

        public bool insert(Article article)
        {
          if(article == null)
            {
                return false;
            }
          if(this._conn.State == ConnectionState.Open) {
                IDbCommand cmdInsert = this._conn.CreateCommand();
                //Hier wird die sql Statement angegeben 
                // es müssen immer Parameter (z.b. @Article) verwendet werden, da durch SQL-Injections verhindert werden
                //SQL Injection: der Angreifer versucht z.b.  über ein Formularelement SQL einzuschleusen z.b. Delet from User Dieser Code würde ohne Partameter ausgeführt werden und die Tabelle würde komplett gelöscht werden
                cmdInsert.CommandText = "insert into articles values(null, @Cityname, @Sightseeing, @Description, @Country);";
                IDbDataParameter paramArticle = cmdInsert.CreateParameter();
                paramArticle.ParameterName = "Cityname";
                paramArticle.DbType = DbType.String;
                paramArticle.Value = article.Cityname;
                IDbDataParameter paramArticleSight = cmdInsert.CreateParameter();
                paramArticleSight.ParameterName = "Sightseeing";
                paramArticleSight.DbType = DbType.String;
                paramArticleSight.Value = article.Sightseeing;
                IDbDataParameter paramArticleSightDesc = cmdInsert.CreateParameter();
                paramArticleSightDesc.ParameterName = "Description";
                paramArticleSightDesc.DbType = DbType.String;
                paramArticleSightDesc.Value = article.Description;
                IDbDataParameter paramArticleSightCount = cmdInsert.CreateParameter();
                paramArticleSightCount.ParameterName = "Country";
                paramArticleSightCount.DbType = DbType.Int32;
                paramArticleSightCount.Value = article.Country;
                //nun müssen  sie verbunden werden 
                cmdInsert.Parameters.Add(paramArticle);
                cmdInsert.Parameters.Add(paramArticleSight);
                cmdInsert.Parameters.Add(paramArticleSightDesc);
                cmdInsert.Parameters.Add(paramArticleSightCount);
                //nun kann der SQL-Command an den DB-Server gesendet werden 
                //ExecuteNonQuery() git die Anzahl der betroffenen Datensätze zurück
                //ExecuteNonQuery() wird bei insert, UPDATe, ... benötigt
                //ExceCuteBody()
                return cmdInsert.ExecuteNonQuery() == 1;
               /* if (cmdInsert.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }*/

            }
            return false;
        }

        public void Open()
           /// öffnet die Datenbankverbindung
        {
            if(this._conn == null)
            {//INstanz für die Verbindung erzeugen
                //Die Verbindung ist noch nicht geöffnet
                this._conn = new MySqlConnection(this._connectionString);
                
            }//nur wenn die Verbindung noch nicht geöffnet wurde
            if (this._conn.State != System.Data.ConnectionState.Open)
            { //...wird sie geöffnet
                this._conn.Open();
            }
        }
        /// <summary>
        /// Schlißt die DB verbindung 
        /// </summary>
      
        public bool update(int CityID, Article newCityData)
        {

            throw new NotImplementedException();
        }
    }
}
