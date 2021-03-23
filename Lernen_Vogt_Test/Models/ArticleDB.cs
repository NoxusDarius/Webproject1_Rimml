using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
namespace Lernen_Vogt_Test.Models
{
    public class ArticleDB : IArticleDB
    {
        private string _connectionString = "server=localhost;database=db_testLernen;user=root;pwd=Airbase11";
        private MySqlConnection _conn = null;
       public  void Open()
        {
            if( this._conn == null)
            {
                this._conn = new MySqlConnection(this._connectionString);
            }
            if(this._conn.State != ConnectionState.Open)
            {
                this._conn.Open();
            }
            
        }
        public void Close()
        {
            if((this._conn.State == ConnectionState.Open) && (this._conn != null))
            {
                this._conn.Close();
            }
        }
        public bool Delete(int article_ID)
        {
            if(this._conn.State == ConnectionState.Open)
            {
                DbCommand cmdDelete = this._conn.CreateCommand();
                cmdDelete.CommandText = "delete from test where article_id =" + article_ID;
                return cmdDelete.ExecuteNonQuery() == 1;

            }
            throw new Exception("Verbindung zur DB ist nicht geöffnet!");
        }
        public bool Update(int article_ID, Article newArticleData)
        { 
            if(this._conn.State == ConnectionState.Open)
            {
                DbCommand cmdUpdate = this._conn.CreateCommand();
                cmdUpdate.CommandText = "update test set name='"+newArticleData.name+"' , description='"+newArticleData.beschreibung+ "' , price="+newArticleData.preis+" where article_ID=" + article_ID+";";
                return cmdUpdate.ExecuteNonQuery() == 1;
                  

            }
                throw new Exception("Verbindung zur DB ist nicht geöffnet!");

        }
        public List<Article> GetAllArticles()
        {

            if (this._conn.State == ConnectionState.Open)
            {
                List<Article> articles = new List<Article>();


                DbCommand cmdSelect = this._conn.CreateCommand();

                cmdSelect.CommandText = "select * from test order by article_ID";

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articles.Add(new Article
                        {

                            article_ID = Convert.ToInt32(reader["article_ID"]),
                            name = Convert.ToString(reader["name"]),
                            beschreibung = Convert.ToString(reader["description"]),
                            preis = Convert.ToDouble(reader["price"]),


                        });
                    }

                }

                if (articles.Count == 0)
                {
                    return null;
                }

                return articles;
            }

            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }
        public Article GetArticleById(int article_ID)
        {
            if(this._conn.State == ConnectionState.Open){

                Article a = new Article();
                DbCommand cmdgetarticlebyID = this._conn.CreateCommand();
                cmdgetarticlebyID.CommandText = "select * from test where article_ID=" + article_ID + ";";
                using (DbDataReader reader = cmdgetarticlebyID.ExecuteReader())
                {
                    while(reader.Read())
                    {
                       a = new Article
                        { 
                            article_ID = Convert.ToInt32(reader["article_ID"]),
                            name = Convert.ToString(reader["name"]),
                            beschreibung = Convert.ToString(reader["description"]),
                            preis = Convert.ToDouble(reader["price"]),

                        };
                    }
                    
                }
                if (a == null)
                {
                    return null;
                }
                return a;



            }
            throw new NotImplementedException();
        }

        public bool Insert(Article article)
        {
            if (article == null)
            {
                return false;
            }
            if (this._conn.State != ConnectionState.Open)
            {
                return false;
            }


            DbCommand cmdInsert = this._conn.CreateCommand();


            cmdInsert.CommandText = "insert into test values(null, @name , @description, @price);";


            DbParameter paramArticlename = cmdInsert.CreateParameter();

            paramArticlename.ParameterName = "name";
            paramArticlename.DbType = DbType.String;
            paramArticlename.Value = article.name;

            DbParameter paramDescription = cmdInsert.CreateParameter();
            paramDescription.ParameterName = "description";
            paramDescription.DbType = DbType.String;
            paramDescription.Value = article.beschreibung;

            DbParameter paramPrice = cmdInsert.CreateParameter();
            paramPrice.ParameterName = "price";
            paramPrice.DbType = DbType.Double;
            paramPrice.Value = article.preis;




            cmdInsert.Parameters.Add(paramArticlename);
            cmdInsert.Parameters.Add(paramPrice);
            cmdInsert.Parameters.Add(paramDescription);


            return cmdInsert.ExecuteNonQuery() == 1;

        }


    }
}
