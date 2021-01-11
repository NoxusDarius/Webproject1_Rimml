using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stadt_Vogt_Aufgabe1.Models.DB
{
    interface Interface
    {
        void Open();
        void Close();
        Article GetCityByID(int CityID);
        List<Article> GetCities();
        bool Delete(int CityID);
        bool update(int CityID, Article newCityData);
        bool insert(Article article);
        //weitere Methoden 
    }
}
