using System;
using System.Collections.Generic;
using System.Text;

namespace StarSpinz_Casino.UserScreen
{
    public static class Games
    {

        internal static void PlayGame()
        {
            Console.Clear();
            Console.WriteLine("\nMatch the casino's suit to win!");
            Utilities.PressEnter();
            string PlayAgain = "y";
            while (PlayAgain == "y")
            {
                Console.Clear();
                string Suit = null; 
                Random random = new Random();
                int casino = random.Next(1, 4);
                switch (casino)
                {
                    case 1:
                        Suit = "Clubs";
                        break;
                    case 2:
                        Suit = "Spades";
                        break;
                    case 3:
                        Suit = "Hearts";
                        break;
                    case 4:
                        Suit = "Diamonds";
                        break;
                }
                Console.WriteLine($"\nGame in Progress..");
                Utilities.Timer();
                Console.WriteLine($"\nThe Casino spun {Suit} ");
                int player = random.Next(1, 4);
                switch (player)
                {
                    case 1:
                        Suit = "Clubs";
                        break;
                    case 2:
                        Suit = "Spades";
                        break;
                    case 3:
                        Suit = "Hearts";
                        break;
                    case 4:
                        Suit = "Diamonds";
                        break;
                }
                Console.WriteLine($"\nYour turn..");
                Utilities.Timer();
                Console.WriteLine($"\nYou spun {Suit} ");
                if (casino == player)
                    Console.WriteLine("\nCongratulations, you won!");
                else
                    Console.WriteLine("\nSorry, you didn't win this time.");
                Console.WriteLine("\nPlay Again?");
                PlayAgain = Console.ReadLine();
            }          
           
        }
    }
}
