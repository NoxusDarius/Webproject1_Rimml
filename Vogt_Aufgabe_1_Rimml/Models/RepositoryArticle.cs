using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vogt_Aufgabe_1_Rimml.Models
{
    public class RepositoryArticle :IRepositoryArticle
    {
      
        private string _connectionString = "server=localhost;database=db_shop;user=root;pwd=Airbase11";
       
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

        public bool Delete(int article_ID)
        {
            if (this._conn.State == ConnectionState.Open)
            {
                DbCommand cmdDelete = this._conn.CreateCommand();
                cmdDelete.CommandText = "delete from articles where article_id = " + article_ID;

                return cmdDelete.ExecuteNonQuery() == 1;
            }
            throw new Exception("Verbindung zur DB ist nicht geöffnet!");
        }

        public List<Article> GetAllArticles()
        {

            if (this._conn.State == ConnectionState.Open)
            {
                List<Article> articles = new List<Article>();

                
                DbCommand cmdSelect = this._conn.CreateCommand();

                cmdSelect.CommandText = "select * from articles order by article_id";

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articles.Add(new Article
                        {
                           
                            Article_ID = Convert.ToInt32(reader["article_id"]),
                            Name = Convert.ToString(reader["name"]),
                            Description = Convert.ToString(reader["description"]),
                            Price = Convert.ToDouble(reader["price"]),
                            

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

           
            cmdInsert.CommandText = "insert into articles values(null, @name , @description, @price);";

          
            DbParameter paramArticlename = cmdInsert.CreateParameter();
           
            paramArticlename.ParameterName = "name";
            paramArticlename.DbType = DbType.String;
            paramArticlename.Value = article.Name;

            DbParameter paramDescription = cmdInsert.CreateParameter();
            paramDescription.ParameterName = "description";
            paramDescription.DbType = DbType.String;
            paramDescription.Value = article.Description;

            DbParameter paramPrice = cmdInsert.CreateParameter();
            paramPrice.ParameterName = "price";
            paramPrice.DbType = DbType.Double;
            paramPrice.Value = article.Price;

           

           
            cmdInsert.Parameters.Add(paramArticlename);
            cmdInsert.Parameters.Add(paramPrice);
            cmdInsert.Parameters.Add(paramDescription);
            

            return cmdInsert.ExecuteNonQuery() == 1;
          
        }

        public bool Update(int article_ID, Article newArticleData)
        {
            throw new NotImplementedException();
        }
    
}
}
