using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lernen_Vogt_Test.Models
{
    interface IArticleDB
    {
         void Open();
        void Close();

       Article GetArticleById(int article_ID);
        List<Article> GetAllArticles();
       bool Insert(Article article);
        bool Delete(int article_ID);
        bool Update(int article_ID, Article newArticleData);

    }
}
