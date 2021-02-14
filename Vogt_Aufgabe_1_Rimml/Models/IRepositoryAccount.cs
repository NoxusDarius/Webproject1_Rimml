using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vogt_Aufgabe_1_Rimml.Models
{
    interface IRepositoryAccount
    {
        void Open();
        void Close();
       
        registration GetAllRegistrationbyID(int registration_ID);
        List<registration> GetAllRegistration();
        bool Insert(registration registration);
        
      
    }
}
