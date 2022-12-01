using StarSpinz_Casino.UserScreen;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarSpinz_Casino.Code
{
    class Start
    {
        static void Main(string[] args)
        {
            Homescreen.Login();                      
            StarSpinz_Casino starSpinz_Casino = new StarSpinz_Casino();
            starSpinz_Casino.PopulateAccounts();
            starSpinz_Casino.CheckUserExists();            
            starSpinz_Casino.CheckUserPassword();            
            Utilities.PressEnter();          
            
        }
    }
}
