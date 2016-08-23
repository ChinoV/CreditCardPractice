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
                              + "5: to check your Transactions\n6: To change your pin\n Press 0 to exit.\n");
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
            Console.WriteLine("\nPlease type in your I.D.");
            int ClientId; 
            int.TryParse(Console.ReadLine().ToString(), out ClientId);
            return ClientId;
        }

        public void PrintErrorTxt()
        {
            Console.WriteLine("Wrong Password or Client I.D");
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
