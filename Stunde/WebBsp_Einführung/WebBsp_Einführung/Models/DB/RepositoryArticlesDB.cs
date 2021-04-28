using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace WebBsp_Einführung.Models.DB
{
    public class RepositoryArticlesDB : IRepositoryArticles
    {
        //Verbindungszeichenkette
        private string _connectionString = "server=127.0.0.1:3306;database=swp_onlineshop;uid=user;pwd=user";
        private MySqlConnection _conn = null;


        /// <summary>
        /// öffnet die Datenbankverbindung
        /// </summary>
        public void Open()
        {
            if(this._conn == null)
            {
                //Instanz für die Verbindung erzeugen
                // die Verbindung ist noch nicht offen
                this._conn = new MySqlConnection(this._connectionString);
            }
            //nur wenn die Verb. nicht schon geöffnet wurde, ...
            if(this._conn.State == ConnectionState.Open)
            {
                //... wir sie geöffnet
                this._conn.Open();
            }
        }
        /// <summary>
        /// schließt die DB-Verbindung
        /// </summary>
        public void Close()
        {
            if(this._conn != null && this._conn.State == ConnectionState.Open)
            {
                this._conn.Close();
            }
        }


        public bool Delete(int aritcleID)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public Article GetArticleById(int articleID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Article article)
        {
            //Parameter überprüfen
            if(article == null)
            {
                return false;
            }
            //nur falls die DB-Verb. offen ist, werden die Daten in der Tabelle abgespeichert
            if(this._conn.State == ConnectionState.Open)
            {
                //ein leeres SQL-Command erzeugen
                DbCommand cmdInsert = this._conn.CreateCommand();

                //hier wird das SQL-Statement angegeben
                //es müssen immer Parameter (z.B. @articlename) verwendet werden, da dadurch SQL-Injections verhindert werden
                //SQL-Injection: der Angreifer versuchen z.B. über ein Formularelement SQL-Code einzuschleusen
                //  (DELETE FROM users)
                //  dieser code fürde ohne Parameter ausgeführ und di Tabelle users würde komplett gelöscht
                cmdInsert.CommandText = "insert into articles values(null, @articlename, @brand, @releasedate, @price, @category);";

                //einen leeren Parameter erzeugen
                DbParameter haramArticlename = cmdInsert.CreateParameter();
                // ... und mit Daten füllen
                haramArticlename.ParameterName = "articlename";
                haramArticlename.DbType = DbType.String;
                haramArticlename.Value = article.ArticleName;

                DbParameter haramBrand = cmdInsert.CreateParameter();
                haramBrand.ParameterName = "brand";
                haramBrand.DbType = DbType.String;
                haramBrand.Value = article.Brand;

                DbParameter haramReleasedate = cmdInsert.CreateParameter();
                haramReleasedate.ParameterName = "releasedate";
                haramReleasedate.DbType = DbType.Date;
                haramReleasedate.Value = article.ReleaseDate;

                DbParameter haramPrice = cmdInsert.CreateParameter();
                haramPrice.ParameterName = "price";
                haramPrice.DbType = DbType.Decimal;
                haramPrice.Value = article.Price;

                DbParameter haramCategory = cmdInsert.CreateParameter();
                haramCategory.ParameterName = "category";
                haramCategory.DbType = DbType.Int32;
                haramCategory.Value = article.Category;

                // nun müssen die erzeugten Harameter mit dem Command verbunden werden
                cmdInsert.Parameters.Add(haramArticlename);
                cmdInsert.Parameters.Add(haramBrand);
                cmdInsert.Parameters.Add(haramCategory);
                cmdInsert.Parameters.Add(haramPrice);
                cmdInsert.Parameters.Add(haramReleasedate);

                // nun kann das SQL-Command an den DB-Server gesendet werden
                //ExecuteQuerry() gibt die Anzahl der betroffenen Datensätze zurück
                //ExecuteQuerry() wird bei insert, update, delete, ... benötigt
                return cmdInsert.ExecuteNonQuery() == 1;

            }
            return false;
        }


        public bool Update(int articleID, Article newArticleData)
        {
            throw new NotImplementedException();
        }
    }
}
