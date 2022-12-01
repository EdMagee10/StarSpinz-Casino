using System;
using System.Collections.Generic;
using System.Text;

namespace StarSpinz_Casino.Data.Items
{
    public class AccountDetails
    {
        public int AccountId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string BankAccount { get; set; }
        public bool LockedOut { get; set; }

    }
}