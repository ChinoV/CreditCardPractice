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
        public Account()
        {
            this.accId = "cta- " + 1;
            this.balanceAvailable = 100000;
            this.balanceDue = 0;
            this.credit = 100000;
            this.Blocked = false;
            this.Transactions = new List<Transaction>();
        }

        public Account(string accId)
        {
            this.accId = accId;
            this.balanceAvailable = 100000;
            this.balanceDue = 0;
            this.credit = 100000;
            this.Blocked = false;
            this.Transactions = new List<Transaction>();
        }

        public Account(string accId,double credit)
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
            return "Accounts: " + accId;
        }


        public void PayAmount(double AmountToPay)
        {
            //if()
            //balanceAvailable;
            //balanceDue;
        }
        public void Withdraw(double Amount)
        {
            if (Amount <= balanceAvailable)
            {
                this.balanceDue += Amount;
                this.balanceAvailable -= Amount;
            }
        }
        
        #endregion
  
    }
}
