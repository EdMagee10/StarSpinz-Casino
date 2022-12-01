using StarSpinz_Casino.Data;
using StarSpinz_Casino.Data.Items;
using StarSpinz_Casino.Data.Menu;
using StarSpinz_Casino.UserScreen;
using System;
using System.Collections.Generic;

namespace StarSpinz_Casino
{
    public class StarSpinz_Casino : ILogin
    {
        private List<AccountDetails> UserList;
        private AccountDetails SelectAccount;

        public void CheckUserPassword()
        {
           
            bool CorrectPassword = false;
            int NumberLogins = 0;
            while ((CorrectPassword == false) && (NumberLogins < 3))
            {
              
                Console.WriteLine("Enter your password:");
                AccountDetails inputAccount = Homescreen.LoginForm();
                foreach (AccountDetails account in UserList)
                {
                    SelectAccount = account;
                   
                    if (inputAccount.Password.Equals(SelectAccount.Password))
                    {
                        CorrectPassword = true;
                        Console.WriteLine("\nLogging in");
                        Utilities.Timer();
                        Console.WriteLine($"\nWelcome back {SelectAccount.Name}!");
                        Console.WriteLine($"\nYou are now logged in to StarSpinz Casino!");
                        Utilities.PressEnter();
                        
                        int options = 1;
                        while (options != 5)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n********************* Welcome to StarSpinz Casino!*********************");
                            Console.WriteLine("\n\n*********************             Menu            *********************");
                            Console.WriteLine("1. Account Balance                                                        :");
                            Console.WriteLine("2. Deposit                                                                :");
                            Console.WriteLine("3. Withdrawal                                                             :");
                            Console.WriteLine("4. Play Game                                                              :");
                            Console.WriteLine("5. Exit                                                                   :");
                            Console.WriteLine("\nEnter an option 1-5");


                            options = int.Parse(Console.ReadLine());
                            switch (options)
                            {
                                case 1:
                                    Console.WriteLine($"\nYour account balance is: {Utilities.FormatCurrency(SelectAccount.Balance)}");
                                    Utilities.PressEnter();
                                    break;
                                case 2:
                                    Console.WriteLine("\nEnter a deposit amount:");
                                    decimal deposit = decimal.Parse(Console.ReadLine());
                                    SelectAccount.Balance = SelectAccount.Balance + deposit;
                                    Console.WriteLine($"\nYour account balance is now: {Utilities.FormatCurrency(SelectAccount.Balance)}");
                                    Utilities.PressEnter();
                                    break;
                                case 3:
                                    Console.WriteLine("\nEnter a withdrawal amount:");
                                    decimal withdrawal = decimal.Parse(Console.ReadLine());
                                    Console.WriteLine("\nEnter a Bank Account number to withdraw to.");
                                    string withdrawAccount = Console.ReadLine();
                                    Console.WriteLine("\nContacting your bank...");
                                    Utilities.Timer();
                                    if ((withdrawAccount == SelectAccount.BankAccount)&&((SelectAccount.Balance - withdrawal)>=0 ))
                                    {
                                        Console.WriteLine("\nWithdrawal successful...");
                                        SelectAccount.Balance = SelectAccount.Balance - withdrawal; 
                                    }
                                        else Console.WriteLine("\nWithdrawal failed...Incorrect bank details or withdrawal ammount is greater than your balance.");
                                    Console.WriteLine($"\nYour account balance is now: {Utilities.FormatCurrency(SelectAccount.Balance)}");
                                    Utilities.PressEnter();
                                    break;                                    
                                case 4:
                                    Games.PlayGame();
                                    break;
                                case 5:
                                    Utilities.Logout();
                                    break;
                                default:                                    
                                    break;
                            }


                        }
                    }

                }
                if (CorrectPassword == false)
                {
                    Console.WriteLine("\nInvalid Login");
                    NumberLogins++;   
                }
                if (NumberLogins == 3) 
                    if (SelectAccount.LockedOut ==true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nAccount Locked. Please contact help@starspinzcasino to reset your account.");
                }                  
                                  
            }
            
        }



        public void PopulateAccounts()
        {
            UserList = new List<AccountDetails>
            {
                new AccountDetails{AccountId = 0001, Name = "Steve Cutajar", Password = "Malta", Balance = 400.00M, BankAccount = "1234", LockedOut = false},
                new AccountDetails{AccountId = 0002, Name = "Lucas Paqueta", Password = "Brazil", Balance = 10.00M, BankAccount = "5678", LockedOut = false },
                new AccountDetails{AccountId = 0003, Name = "Bjorn Knudsen", Password = "Sweden", Balance = 30.00M, BankAccount = "1111", LockedOut = true}
            };
        }

        public void CheckUserExists()
        {
            Console.WriteLine("Enter your name:");
            AccountDetails inputAccount = Homescreen.NewUser();
            Console.WriteLine("\nFinding you in our system...");
            Utilities.Timer();
            string name = inputAccount.Name;
            bool PlayerExists = false;
            while (PlayerExists == false)
            {
                
                foreach (AccountDetails account in UserList)
                {
                    SelectAccount = account;
                    if (inputAccount.Name.Equals(SelectAccount.Name))
                    {
                        Console.WriteLine($"\nWelcome!{SelectAccount.Name}");
                        PlayerExists = true;
                    }

                }
                if (PlayerExists == false)
                {
                    Console.WriteLine("\nSorry we cant find you in our system...");
                    Console.WriteLine("\nWould you like to register with StarSpinz Casino ?");
                   
                    string reply = Console.ReadLine();
                    if (reply == "y")
                    {
                        Console.WriteLine("\nEnter a password:");
                        string password = Console.ReadLine();
                        Console.WriteLine("\nEnter your bank account number:");
                        string bankaccount = Console.ReadLine();
                        UserList.Add(new AccountDetails { AccountId = 0004, Name = ($"{ name }"), Password = ($"{password}"), Balance = 0.00M, BankAccount = ($"{bankaccount}") , LockedOut = false});
                    }
                    else Environment.Exit(0);
                }

            }
            
        }
                
        
    }

}

