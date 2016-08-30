using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Logic
{
    class Account
    {
        public string accId { get; set; }
        public double balanceAvailable { get; set; }
        public double balanceDue { get; set; }
        public double credit { get; set; }
        public bool Blocked { get; set; }
        public List<Transaction> Transactions { get; set; }



        #region Methods

        public Account(string accId)
        {
            this.accId = accId;
            this.balanceAvailable = 100000;
            this.balanceDue = 0;
            this.credit = 100000;
            this.Blocked = false;
            this.Transactions = new List<Transaction>();
        }

        public Account(string accId, double credit)
        {
            this.accId = accId;
            this.balanceAvailable = credit;
            this.balanceDue = 0;
            this.credit = credit;
            this.Blocked = false;
            this.Transactions = new List<Transaction>();
        }

        public string AccToString()
        {
            string AccInfo;
            string accStatus;

            if (Blocked)
            {
                accStatus = "Blocked";
            }
            else
            {
                accStatus = "Unblocked";
            }

            AccInfo = "Account Id: " + accId + "\n" +
                      "Account Status: " + accStatus + "\n" +
                      "Credit: " + credit + "\n" +
                      "Balance available: " + balanceAvailable + "\n" +
                      "Balance owed: " + balanceDue;

            return AccInfo;

        }
        

        public string AccBalanceString()
        {
            string AccBalance = "Balance available: " + balanceAvailable + "\n" +
                             "Balance owed: " + balanceDue;
            return AccBalance;
        }



        public void Buy (double Amount)
        {
            if (Amount <= balanceAvailable)
            {
                int countTransactions = Transactions.Count;
                this.balanceDue += Amount;
                this.balanceAvailable -= Amount;
                Transactions.Add(new Transaction("Purchase", Amount, ++countTransactions));
            }
        }
        public bool Withdraw(double Amount)
        {
            if (Amount <= balanceAvailable)
            {
                int countTransactions = Transactions.Count;
                this.balanceDue += Amount+ credit * 0.01;
                this.balanceAvailable = credit-balanceDue;
                Transactions.Add(new Transaction("Withdrawal", Amount, ++countTransactions));
                return true;
            }
            return false;
        }

        public bool PayCc(double Amount)
        {
            int countTransactions = Transactions.Count;

            if(balanceDue>=5000 && Amount>=5000 && Amount <= balanceDue)
            {
                this.balanceDue -= Amount;
                this.balanceAvailable += Amount;
                Transactions.Add(new Transaction("Credit Card Payment", Amount, ++countTransactions));
                if (balanceDue!=0)
                {
                    balanceDue += 5* balanceDue / 100;
                }
                return true;
            }
            else if (balanceDue < 5000 && Amount == balanceDue)
            {
                this.balanceDue -= Amount;
                this.balanceAvailable += Amount;
                Transactions.Add(new Transaction("Credit Card Payment", Amount, ++countTransactions));
                return true;
            }
            return false;
        }

        
        
        
        #endregion
  
    }
}
