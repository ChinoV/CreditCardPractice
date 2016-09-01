using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.UI
{
    class UIMenuAcc
    { 
        public int MenuAccDemo()
        {
            int option;
            Console.WriteLine("\nAccount's Menu\nPress \n1: to Withdraw money \n2: to Pay your credit card \n3: to buy an article \n4: to check your balance \n"
                              + "5: to check your Transactions\n6: To change your pin\n7: to exit.\n");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out option);
            return option;

        }

        public string ClientPasswordRequestDemo()
        {
            Console.WriteLine("\nPlease type in your password");
            string inputPassword = Console.ReadLine();
            return inputPassword;
        }

        public int RequestClientId()
        {
            Console.WriteLine("\nPlease type in your Id.");
            int ClientId; 
            int.TryParse(Console.ReadLine().ToString(), out ClientId);
            return ClientId;
        }

        public string RequestAccId()
        {
            Console.WriteLine("\nPlease type in your Account's Id.");
            string password = Console.ReadLine();
            return password;
        }

        public string RequestNewPassword()
        {
            Console.WriteLine("\nType in your new password:");
            string password = Console.ReadLine();
            return password;
        }

        public string RequestNewPassword2()
        {
            Console.WriteLine("\nConfirm your new password:");
            string accId = Console.ReadLine();
            return accId;
        }


        public double RequestAmount()
        {
            double amount;
            Console.WriteLine("\nPlease type in the amount");            
            double.TryParse(Console.ReadLine().ToString(), out amount);
            return amount;
        }


        public void DisplayAccInfo(string pAccInfo)
        {

            if (pAccInfo != "")
            {
                Console.WriteLine("\n"+ pAccInfo);
            }
            else
            {
                Console.WriteLine("No acc found with that I.D.");
            }
        }

        public void DisplayAmountWithdrawn(double pAmount)
        {
            Console.WriteLine("\nAmount withdrawn: " + pAmount);
        }

        public double DisplayAmountPayed(double pAmount)
        {
            Console.WriteLine("\nAmount payed: " + pAmount);
            return pAmount;
        }

        public void DisplayTransactions(string pTrans)
        {

            if (pTrans != "")
            {
                Console.WriteLine(pTrans);
            }
            else
            {
                Console.WriteLine("No transactions have been made with this account");
            }
        }


        public void PrintAccessErrorTxt()
        {
            Console.WriteLine("Wrong Password or Client Id.");
        }

        public void PrintCcPaymentErrorTxt()
        {
            Console.WriteLine("Invalid amount");
        }

        public List<double> RequestAmountsToBuy()
        {
            List<double> values = new List<double>(5);
            int option;
            do {
                Console.WriteLine("\nType in Amount:");
                double value;
                double.TryParse(Console.ReadLine().ToString(), out value);
                values.Add(value);
                Console.WriteLine("\nPress 7 to end or enter to keep adding amounts.");
                int.TryParse(Console.ReadLine().ToString(), out option);
            } while (option!=7);
            return values;
        }

        //public void MenuAcc(int UserType)
        //{
        // while (UserType!=0)
        //    {
        //        Console.WriteLine("Account Menu\nPress \n 1: to withdraw money \n 2: to pay your credit card \n 3: to buy an article \n 4: to check your balance \n 5: to check your Transactions\n 6: To change your pin\n Press 0 to exit.\n");
        //        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out UserType) == true)
        //        {
        //            if (UserType != 0)
        //            {
        //                switch (UserType)
        //                {
        //                    case 1:

        //                        //to withdraw money


        //                        break;
        //                    case 2:

        //                        break;
        //                    case 3:

        //                        break;
        //                    case 4:

        //                        break;
        //                    case 5:

        //                        break;
        //                    case 6:

        //                        break;
        //                    default:

        //                        break;
        //                }
        //            }
        //        }



    }
}
