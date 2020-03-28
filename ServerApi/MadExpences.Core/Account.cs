using System;
using System.Collections.Generic;
using System.Text;

namespace MadExpences.Core
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public DateTime CreationDate { get; set; }
        public float InitalBalance { get; set; }
        public float Balance { get; set; }
        public AccountType AccountType { get; set; }
        
    }

    public enum AccountType
    {
        Debit = 1,
        Credit = 2,
        Savings = 3,
    }
}
