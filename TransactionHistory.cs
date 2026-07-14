using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartbankUI
{
    internal class TransactionHistory
    {
        public string TransactionType { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }

        public TransactionHistory(string transactionType, double transactionAmount)
        {
            TransactionType = transactionType;
            TransactionAmount = transactionAmount;
            TransactionDate = DateTime.Now;
        }

        public void DisplayTransaction()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "========================================================\n" +
                $"{TransactionType} took place on {TransactionDate}\n" +
                $"{TransactionAmount} Transacted\n" +
                "========================================================\n"
            );
        }
    }
}
