using StarSpinz_Casino.Data.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarSpinz_Casino.UserScreen
{
    public static class Homescreen
    {
        internal static void Login()
        {
            Console.Clear();
            Console.Title = "StarSpinz Casino";
            Console.WriteLine("\n\n********************* Welcome to StarSpinz Casino!*********************");
            Utilities.PressEnter();
        }

        internal static AccountDetails LoginForm()
        {
            AccountDetails tempUser = new AccountDetails();
            tempUser.Password = Utilities.HideUserDetails("");            
            return tempUser;
        }

        internal static AccountDetails NewUser()
        {
            AccountDetails tempUser = new AccountDetails();            
            tempUser.Name = Utilities.GetUserInfo("");          
            return tempUser;
        }

        internal static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n********************* Welcome to StarSpinz Casino!*********************");
            Console.WriteLine("\n\n*********************             Menu            *********************");
            Console.WriteLine("1. Account Balance                                                        :");
            Console.WriteLine("2. Deposit                                                                :");
            Console.WriteLine("3. Withdrawal                                                             :");
            Console.WriteLine("4. Play Game                                                              :");
            Console.WriteLine("5. Exit                                                                   :");
            Console.WriteLine("\nEnter an option:");

            
            string options = Console.ReadLine();
            switch (options)
            {
                
                case "4":
                    Games.PlayGame();
                    break;
                case "5":
                    Utilities.Logout();
                    break;

            }


        }
        
        


    }
}
