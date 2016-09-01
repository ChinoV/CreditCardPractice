using ConsoleApplication2.Logic;
using ConsoleApplication2.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Gestor objGestor = new Gestor();
            UIMenuPrincipal MenuP = new UIMenuPrincipal(objGestor);
            UIMenuAcc MenuA = new UIMenuAcc();

            ProgramMenu(objGestor, MenuP, MenuA);
        }

        private static void AdminPassword(Gestor pObjGestor, UIMenuPrincipal pMenuP)
        {
            if (pObjGestor.ValidateAdminStatus())
            {
                bool result;
                do
                {
                    result = pObjGestor.ValidateAdminPassword(pMenuP.AdminPasswordRequestDemo());
                }
                while (result == false);
            }
        }

        private static void SecondMenu(Gestor pObjGestor, UIMenuAcc pMenuA)
        {
            int ClientId = pMenuA.RequestClientId();
            int option;
            pObjGestor.SetUserInSesion(ClientId);

            if (pObjGestor.ClientExists(ClientId) && pObjGestor.ValidateAccStatus() && pObjGestor.ValidateClientPassword(pMenuA.ClientPasswordRequestDemo()))
            {
                pObjGestor.SetAccInSesion(pMenuA.RequestAccId());
                do
                {
                    option = pMenuA.MenuAccDemo();

                    switch (option)
                    {

                        case 1:
                            //1: to Withdraw Money
                            pMenuA.DisplayAmountWithdrawn(pObjGestor.WithdrawMoney(pMenuA.RequestAmount()));
                            pMenuA.DisplayAccInfo(pObjGestor.GetAccInSesionInfo());

                            break;
                        case 2:

                            //2: to Pay your credit card
                            while (pMenuA.DisplayAmountPayed(pObjGestor.PaymentCc(pMenuA.RequestAmount())) == 0)
                            {
                                pMenuA.PrintCcPaymentErrorTxt();
                            }

                            pMenuA.DisplayAccInfo(pObjGestor.GetAccInSesionInfo());

                            break;
                        case 3:

                            //3: to Buy an article
                            pObjGestor.BuyArticle(pMenuA.RequestAmountsToBuy());
                            pMenuA.DisplayAccInfo(pObjGestor.GetAccInSesionInfo());

                            break;
                        case 4:
                            //4: to check acc Balance
                            pMenuA.DisplayAccInfo(pObjGestor.GetAccInSesionBalance());

                            break;
                        case 5:

                            //5: to check your Transactions
                            pMenuA.DisplayTransactions(pObjGestor.TxtTransactions());

                            break;
                        case 6:

                            //6: To change your pin
                            if (pObjGestor.ValidateClientPassword(pMenuA.ClientPasswordRequestDemo()))
                            {
                                do
                                {

                                } while (pObjGestor.PasswordChange(pMenuA.RequestNewPassword(), pMenuA.RequestNewPassword2()) == false);
                            }

                            break;
                        default:

                            Console.WriteLine("Invalid Option");

                            break;
                    }
                } while (option != 7);
            }
            else
            {
                pMenuA.PrintAccessErrorTxt();
            }
        }

        private static void OptionOne(Gestor pObjGestor, UIMenuPrincipal pMenuP)
        {
            AdminPassword(pObjGestor, pMenuP);
            var rValues = pMenuP.RegisterDemo2();
            if (pObjGestor.ClientExists(int.Parse(rValues[0])) == false)
            {
                if (string.IsNullOrEmpty(rValues[4]))
                {
                    pObjGestor.RegisterMethodDemo(rValues[1], rValues[2], int.Parse(rValues[0]), int.Parse(rValues[3]), -1);
                }
                else
                {
                    pObjGestor.RegisterMethodDemo(rValues[1], rValues[2], int.Parse(rValues[0]), int.Parse(rValues[3]), double.Parse(rValues[4]));
                }
            }
            else
            {
                pObjGestor.SetUserInSesion(int.Parse(rValues[0]));
                if (string.IsNullOrEmpty(rValues[4]))
                {
                    pObjGestor.AddAccountDemo();
                }
                else
                {
                    pObjGestor.AddAccountDemo(int.Parse(rValues[0]), double.Parse(rValues[4]));
                }

            }

            pMenuP.DisplayUserInfoDemo(pObjGestor.GetUserInfo(int.Parse(rValues[0])));

        }

        private static void OptionTwo(Gestor pObjGestor, UIMenuPrincipal pMenuP)
        {
            AdminPassword(pObjGestor, pMenuP);
            int UserId = pMenuP.GetUserIdDemo();
            if (pObjGestor.ClientExists(UserId))
            {
                var mValues = pMenuP.ModifyDemo();
                pObjGestor.ModifyMethodDemo(UserId, mValues[1], mValues[2], int.Parse(mValues[0]), int.Parse(mValues[3]));
            }
            else
            {
                Console.WriteLine("No user found with that I.D.");
            }

        }

        private static void OptionThree(Gestor pObjGestor, UIMenuPrincipal pMenuP)
        {
            AdminPassword(pObjGestor, pMenuP);
            pMenuP.DisplayUserInfoDemo(pObjGestor.GetUserInfo(pMenuP.GetUserIdDemo()));
        }

        private static void OptionFour(Gestor pObjGestor, UIMenuPrincipal pMenuP)
        {
            AdminPassword(pObjGestor, pMenuP);
            pObjGestor.DisableAdmin();
            Console.WriteLine("admin password disabled");
        }

        private static void OptionFive(Gestor pObjGestor, UIMenuPrincipal pMenuP)
        {
            AdminPassword(pObjGestor, pMenuP);
            int UserId2 = pMenuP.GetUserIdDemo();
            pObjGestor.UnblockClientAccs(UserId2);
        }

        private static void ProgramMenu(Gestor pObjGestor, UIMenuPrincipal pMenuP, UIMenuAcc pMenuA)
        {
            pMenuP.Welcometxt();

            int option = 0;
            do
            {
                option = pMenuP.FirstMenu();

                switch (option)
                {
                    case 1:
                        //Register User or Add Acc to User
                        OptionOne(pObjGestor, pMenuP);
                        break;

                    case 2:
                        //Modify User
                        OptionTwo(pObjGestor, pMenuP);
                        break;

                    case 3:
                        //search for user
                        OptionThree(pObjGestor, pMenuP);
                        break;

                    case 4:
                        //Disable admin password
                        OptionFour(pObjGestor, pMenuP);
                        break;

                    case 5:
                        //Unblock an acc
                        OptionFive(pObjGestor, pMenuP);
                        break;

                    case 6:
                        //Account Menu
                        SecondMenu(pObjGestor, pMenuA);
                        break;

                    default:
                        if (option != 7)
                        {
                            Console.WriteLine("Invalid Option");
                        }

                        break;
                }

            } while (option != 7);
        }
        
    }
}

