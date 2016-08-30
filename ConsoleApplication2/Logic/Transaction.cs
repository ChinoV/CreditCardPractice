using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Logic
{
    class Transaction
    {
        public string Type{ get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int transactionId { get; set; }

        public Transaction(string Type, double Amount, int tId)
        {
            this.Type = Type;
            this.Amount = Amount;
            this.transactionId = tId;
            this.Date = DateTime.Now;
        }

        public string TransactionToString()
        {
            string transaction = "\n"+transactionId + " " +Date + " " + Type + " " + Amount;
             
            return transaction;
        }
    }
}
