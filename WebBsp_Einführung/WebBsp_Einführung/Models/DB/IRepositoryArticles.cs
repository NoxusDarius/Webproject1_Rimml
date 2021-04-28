using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBsp_Einführung.Models.DB
{
    // Repository ... Ablageort
    interface IRepositoryArticles
    {

        void Open();
        void Close();

        Article GetArticleById(int articleID);
        List<Article> GetAllArticles();
        bool Insert(Article article);
        bool Delete(int aritcleID);
        bool Update(int articleID, Article newArticleData);

        //weitere Methoden

    }
}
