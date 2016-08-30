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
            //MenuP.MenuPrincipal(-1);
            Gestor objGestor = new Gestor();
            UIMenuPrincipal MenuP = new UIMenuPrincipal(objGestor);
            UIMenuAcc MenuA = new UIMenuAcc();

            MenuP.Welcometxt();
            
            int option = 0;
            do
            {

            #region PrimaryMenu
                option = MenuP.FirstMenu();
                if (option > 0 && option < 6)
                {
                    
                    //if (objGestor.ValidateAdminStatus())
                    //{
                    //    bool result = false;
                    //    do
                    //    {
                    //        result = objGestor.ValidateAdminPassword(MenuP.AdminPasswordRequestDemo());
                    //    }
                    //    while (result == true);
                    //}
                    switch (option)
                    {
                        case 1:
                            AdminPassword(objGestor, MenuP);
                            var rValues = MenuP.RegisterDemo2();
                            if (objGestor.ClientExists(int.Parse(rValues[0])) == false)
                            {
                                if (string.IsNullOrEmpty(rValues[4]))
                                {
                                    objGestor.RegisterMethodDemo(rValues[1], rValues[2], int.Parse(rValues[0]), int.Parse(rValues[3]));
                                }
                                else
                                {
                                    objGestor.RegisterMethodDemo(rValues[1], rValues[2], int.Parse(rValues[0]), int.Parse(rValues[3]), double.Parse(rValues[4]));
                                }
                            }
                            else
                            {
                                objGestor.SetUserInSesion(int.Parse(rValues[0]));
                                if (string.IsNullOrEmpty(rValues[4]))
                                {
                                    objGestor.AddAccountDemo();
                                }
                                else
                                {
                                    objGestor.AddAccountDemo(int.Parse(rValues[0]), double.Parse(rValues[4]));
                                }

                            }

                            MenuP.DisplayUserInfoDemo(objGestor.GetUserInfo(int.Parse(rValues[0])));

                            break;

                        case 2:
                            AdminPassword(objGestor, MenuP);
                            int UserId = MenuP.GetUserIdDemo();
                            if (objGestor.ClientExists(UserId))
                            {
                                var mValues = MenuP.ModifyDemo();
                                objGestor.ModifyMethodDemo(UserId, mValues[1], mValues[2], int.Parse(mValues[0]), int.Parse(mValues[3]));
                            }
                            else
                            {
                                Console.WriteLine("No user found with that I.D.");
                            }
                            break;

                        case 3:
                            AdminPassword(objGestor, MenuP);
                            MenuP.DisplayUserInfoDemo(objGestor.GetUserInfo(MenuP.GetUserIdDemo()));
                            break;

                        case 4:
                            AdminPassword(objGestor, MenuP);
                            objGestor.DisableAdmin();
                            Console.WriteLine("admin password disabled");

                            break;

                        case 5:
                            AdminPassword(objGestor, MenuP);
                            int UserId2 = MenuP.GetUserIdDemo();
                            objGestor.UnblockClientAccs(UserId2);
                            break;

                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }

                }
                #endregion

            #region 2ndMenu
                
                switch (option)
                {
                    case 6:
                        int ClientId = MenuA.RequestClientId();
                        objGestor.SetUserInSesion(ClientId);
                        
                                if (objGestor.ClientExists(ClientId) && objGestor.ValidateAccStatus() && objGestor.ValidateClientPassword(MenuA.ClientPasswordRequestDemo()))
                            {
                                objGestor.SetAccInSesion(MenuA.RequestAccId());
                                do
                                {
                                    option = MenuA.MenuAccDemo();
                            
                                    switch (option)
                                    {

                                        case 1:
                                            //1: to Withdraw Money
                                            MenuA.DisplayAmountWithdrawn(objGestor.WithdrawMoney(MenuA.RequestAmount()));
                                            MenuA.DisplayAccInfo(objGestor.GetAccInSesionInfo());

                                            break;
                                        case 2:

                                        //2: to Pay your credit card
                                        while (MenuA.DisplayAmountPayed(objGestor.PaymentCc(MenuA.RequestAmount())) == 0)
                                        {
                                            MenuA.PrintCcPaymentErrorTxt();
                                        }

                                            MenuA.DisplayAccInfo(objGestor.GetAccInSesionInfo());


                                            break;
                                        case 3:

                                            //3: to Buy an article
                                            objGestor.BuyArticle(MenuA.RequestAmountsToBuy());
                                            MenuA.DisplayAccInfo(objGestor.GetAccInSesionInfo());

                                            break;
                                        case 4: 
                                            //4: to check acc Balance
                                            MenuA.DisplayAccInfo(objGestor.GetAccInSesionBalance());

                                            break;
                                        case 5:

                                            //5: to check your Transactions
                                            MenuA.DisplayTransactions(objGestor.TxtTransactions());
                                            
                                            break;
                                    case 6:

                                        //6: To change your pin
                                        if (objGestor.ValidateClientPassword(MenuA.ClientPasswordRequestDemo()))
                                        {
                                            do
                                            {

                                            } while (objGestor.PasswordChange(MenuA.RequestNewPassword(), MenuA.RequestNewPassword2()) == false);
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
                                MenuA.PrintAccessErrorTxt();
                            }
                        
                        break;
                }
                #endregion

            } while (option != 7) ;
        }
        public static void AdminPassword(Gestor pObjGestor, UIMenuPrincipal pMenuP)
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

        //public static void 2ndMenu()
        //{

        //}
    }
}

