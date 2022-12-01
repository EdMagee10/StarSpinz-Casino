using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StarSpinz_Casino.UserScreen
{
    public static class Utilities
    {
        
        public static string HideUserDetails(string UserInstruction)
        {
            bool IsUserInstruction = false;
            string starred = "";
            StringBuilder UserInput = new StringBuilder();
            while (true)
            {
                if (IsUserInstruction)
                    Console.WriteLine(UserInstruction);
              
                ConsoleKeyInfo InputKey = Console.ReadKey(true);
                if (InputKey.Key == ConsoleKey.Enter)
                    break;
                if(InputKey.Key == ConsoleKey.Backspace && UserInput.Length > 0)
                {
                    UserInput.Remove(UserInput.Length - 1, 1);
                }
                else if(InputKey.Key != ConsoleKey.Backspace)
                {
                    UserInput.Append(InputKey.KeyChar);
                    Console.Write(starred + "*");

                }
            }
            return UserInput.ToString();
        }
        public static string GetUserInfo(string UserInstruction)
        {
            Console.WriteLine($"{UserInstruction}");
            return Console.ReadLine();
        }
        public static void PressEnter()
        {
            Console.WriteLine("\n\nPress Enter to continue.\n");
            Console.ReadLine();
        }
        public static void Logout()
        {
            Console.WriteLine("Thanks you for playing StarSpinz Casino! You are now safely logged out.");
        }

        public static string FormatCurrency(decimal amount)
        {
            return String.Format( "{0:C2}", amount);
        }

        public static void Timer()
        {
            int timer = 10;
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
        }
       
    }
}
