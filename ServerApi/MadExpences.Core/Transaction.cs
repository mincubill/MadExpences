using System;
using System.Collections.Generic;
using System.Text;

namespace MadExpences.Core
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string TransactionTitle { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionNotes { get; set; }
        public float TransacctionAmmount { get; set; }

    }

    public enum TransactionType
    {
        Expense = 1,
        Income = 2,
    }

}
