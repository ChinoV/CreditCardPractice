using ConsoleApplication2.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.UI
{
    class UIMenuPrincipal
    {
        private Gestor Manager { get; set; }
        
        public UIMenuPrincipal(Gestor Manager)
        {
            this.Manager = Manager;
        }

        public int FirstMenu()
        {
            int option;
            Console.WriteLine("\nPress \n 1: to register an account \n 2: to Modify user data \n 3: to search for user" +
                                      "\n 4: to temporarily disable the administrator password. \n 5: to unblock an account\n 6: to perform transactions.\n 7: to exit.\n");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out option);
            return option;
        }

        public int FirstMenuNoAdmin()
        {
            int option;
            Console.WriteLine("\nPress \n 1: to register an account \n 2: to Modify user data \n 3: to search for user" +
                              "\n 5: to unblock an account\n 6: to perform transactions.\n 7: to exit.\n");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out option);
            return option;
        }

        public List<string> RegisterDemo2()
        {
            List<string> values = new List<string>(5);
            Console.WriteLine("\nType in I.D:");
            values.Add(Console.ReadLine());
            Console.WriteLine("\nType in first name:");
            values.Add(Console.ReadLine());
            Console.WriteLine("\nType in last name:");
            values.Add(Console.ReadLine());
            Console.WriteLine("\nType in Phone Number:");
            values.Add(Console.ReadLine());
            Console.WriteLine("\nType in Credit Limit or press enter to use default amount:");
            values.Add(Console.ReadLine());

            return values;

        }

        public List<string> ModifyDemo()
        {
            List<string> values = new List<string>(5);
            Console.WriteLine("\nType in new I.D:");
            values.Add(Console.ReadLine());
            Console.WriteLine("\nType in new first name:");
            values.Add(Console.ReadLine());
            Console.WriteLine("\nType in new last name:");
            values.Add(Console.ReadLine());
            Console.WriteLine("\nType in new Phone Number:");
            values.Add(Console.ReadLine());
            
            return values;
        }

        public int GetUserIdDemo()
        {
            Console.WriteLine("\nType in I.D:");
            int UserId;
            int.TryParse(Console.ReadLine(), out UserId);

            return UserId;
        }

        public void DisplayUserInfoDemo(string pUserInfo)
        {
           
            if (pUserInfo != "")
            {
                Console.WriteLine(pUserInfo);
            }
            else
            {
                Console.WriteLine("No user found with that I.D.");
            }
        }

        public string AdminPasswordRequestDemo()
        {
            Console.WriteLine("\nPlease type in the Administrator's password");
            string inputPassword = Console.ReadLine();
            return inputPassword;
        }

        public void WrongPasswordDemo()
        {
            Console.WriteLine("Wrong password");
        }

        public void UserExistsDemo()
        {
            Console.WriteLine("\nUser already registererd under that I.D.\nAdded a new account");
            
        }

        private void RegisterUserAccMenuUI()
        {
            Console.WriteLine("\nType in I.D:");
            int UserId;
            int.TryParse(Console.ReadLine(), out UserId);
            if (Manager.FindClientById(UserId)==null)
            {
                Console.WriteLine("\nType in first name:");
                string UserName = Console.ReadLine();
                Console.WriteLine("\nType in last name:");
                string UserLastName = Console.ReadLine();
                Console.WriteLine("\nType in Phone Number:");
                int UserPhone;
                int.TryParse(Console.ReadLine(), out UserPhone);
                Console.WriteLine("\nType in Credit Limit or use default amount:");
                double UserCredit;
                double.TryParse(Console.ReadLine(), out UserCredit);
                Manager.RegisterUserAndAcc(UserName, UserLastName, UserId, UserPhone, false, UserCredit);
                Console.WriteLine("\nA new account has been registered under " + UserName + " " + UserLastName + "'s name with a credit of " + UserCredit + " colones.\n");
            }
            else
            {
                Console.WriteLine("That I.D. is already registered, would you like to create a new account under the same I.D?\n 1-Yes\n2-Return to main menu");
                int YesNo;
                int.TryParse(Console.ReadLine(), out YesNo);
                if (YesNo == 1)
                {

                }
            }
        }

        public int WrongAdminPassword()
        {
            Console.WriteLine("Wrong password\nPress 4 to try again, 7 to exit.\n");
            int option;
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out option);
            return option;
        }

        //public void MenuPrincipal(int UserKey)
        //{
        //    bool On = true;
        //    Manager.AdminPwOnOff(On);
        //    Console.WriteLine("Welcome.");
        //    while (UserKey != 0)
        //    {
        //        if (Manager.AdminPaswordOnOff == true)
        //        {
        //            Console.WriteLine("\nPress \n 1: to register an account \n 2: to Modify user data \n 3: to search for user" +
        //                              "\n 4: to temporarily disable the administrator password. \n 5: to unblock an account\n 6: to perform transactions.\n Press 0 to exit.\n");
        //        }else
        //        {
        //            Console.WriteLine("\nPress \n1: to register an account \n2: to Modify user data \n3: to search for user\n4: to unblock an account\n5: to perform transactions.\nPress 0 to exit.\n");
        //        }
        //        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out UserKey) == true)
        //        {
        //            if (UserKey != 0)
        //            {
                        
        //                if (Manager.AdminPaswordOnOff == true)
        //                {
        //                    if (UserKey >= 1 && UserKey <= 5)
        //                    {
        //                        User Admin = new User("Admin","Admin", 123, 0, true);
        //                        Console.WriteLine("\nType in admin Password");
        //                        string AdminPassword = Console.ReadLine();

        //                        if (AdminPassword == Admin.Password && Manager.AdminPaswordOnOff == true )
        //                        {

        //                            switch (UserKey)
        //                            {
        //                                case 1:
        //                                    RegisterUserAccMenuUI();
        //                                    break;
        //                                case 2:
        //                                    ModifyClientDataUI();
        //                                    break;
        //                                case 3:
        //                                    ConsultByClientUI();
        //                                    break;
        //                                case 4:
        //                                    bool Off = false;
        //                                    Manager.AdminPwOnOff(Off);
        //                                    Console.WriteLine("\nAdministrator password has been temporarily disabled");
        //                                    break;
        //                                case 5:
        //                                    UnblockAccUI();
        //                                    break;

        //                            }
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("\nWrong password, chose again");
        //                        }
        //                    }
                            
        //                }
        //                else
        //                {
        //                    AdminDisabledMenu(UserKey);
        //                }
        //                switch (UserKey)
        //                {
        //                    case 6:
        //                        Console.WriteLine("\nType in your I.D");
        //                        int clientId;
        //                        int tries=0;
        //                        int.TryParse(Console.ReadLine(), out clientId);
        //                        User objUser = Manager.FindClientById(clientId);
        //                        if (objUser != null)
        //                        {
        //                            while (tries < 3)
        //                            {
        //                                Console.WriteLine("Please type in your Password");
        //                                string InputPassword = Console.ReadLine();
        //                                if (objUser.Password == InputPassword)
        //                                {
        //                                    //display transactions menual
        //                                    Console.WriteLine("display transactions menu");
        //                                    tries = 4;
        //                                }
        //                                else
        //                                {
        //                                    Console.WriteLine("\nWrong password");
        //                                    tries++;
        //                                }
        //                            }
        //                            if (tries == 3)
        //                            {

        //                                Manager.BlockClientAccs(objUser);
        //                                Console.WriteLine("Your accounts has been blocked due to three failed attempts,");

        //                            }
        //                        }
                               
        //                        break;
        //                }
                        
        //            }
        //        }
        //    }
        //}

        

        //private void ModifyClientDataUI()
        //{
        //    Console.WriteLine("\nType in the I.D. of the client to be modified");
        //    int clientId;
        //    int.TryParse(Console.ReadLine(), out clientId);
        //    User objUser = Manager.FindClientById(clientId);
        //    if (objUser != null)
        //    {
        //        Console.WriteLine("\nYou have selected " + objUser.Name + " " + objUser.LastName);
        //        Console.WriteLine("\nType in new first name:");
        //        string newUserName = Console.ReadLine();
        //        Console.WriteLine("\nType in new last name:");
        //        string newUserLastName = Console.ReadLine();
        //        Console.WriteLine("\nType in new I.D:");
        //        int newUserId;
        //        int.TryParse(Console.ReadLine(), out newUserId);
        //        Console.WriteLine("\nType in new Phone Number:");
        //        int newUserPhone;
        //        int.TryParse(Console.ReadLine(), out newUserPhone);
        //        string newUserPassword = Manager.PasswordGenerator(newUserName,newUserLastName,newUserId);
        //        Console.WriteLine("\nnew Password: "+newUserPassword);
        //        Manager.ModifyClient(objUser, newUserName, newUserLastName, newUserId, newUserPhone, newUserPassword);
        //        Console.WriteLine("\nClient data:\nName: " + objUser.Name + " " + objUser.LastName + "\nI.D: "+ objUser.UserId + "\nPhone number: "+ objUser.Phone + "\nNew Password: " + objUser.Password);
        //    }
        //    else
        //    {
        //        Console.WriteLine("No user found with that I.D. number");
        //    }

        //}

        //private void ConsultByClientUI()
        //{
        //    Console.WriteLine("\nType in the client's first name");
        //    string ClientFName = Console.ReadLine();
        //    Console.WriteLine("\nType in the client's last name");
        //    string ClientLName = Console.ReadLine();
        //    User objUser = Manager.FindClientByName(ClientFName, ClientLName);
        //    if (objUser != null)
        //    {
        //        Console.WriteLine("\nClient data:\nName: " + objUser.Name + " " + objUser.LastName + "\nI.D: " + objUser.UserId + "\nPhone number: " +
        //                          objUser.Phone + "\nPassword: " + objUser.Password + "\n" );
        //        Console.WriteLine("Accounts: ");
        //        PrintAccountsAndStatus(objUser);

        //    }
        //    else
        //    {
        //        Console.WriteLine("No user found with that name");
        //    }
        //}

        //private void PrintAccountsAndStatus(User Client)
        //{
        //    foreach (Account Acc in Client.Accounts)
        //    {
        //        string AccStatus;
        //        if (Acc.Blocked == true)
        //        {
        //            AccStatus = "blocked";
        //        }
        //        else
        //        {
        //            AccStatus = "unblocked";
        //        }
        //        Console.WriteLine(Acc.accId+" is currently "+AccStatus);
        //    }
        //}

        //private void UnblockAccUI()
        //{
        //    Console.WriteLine("\nType in the client's first name");
        //    string ClientFName = Console.ReadLine();
        //    Console.WriteLine("\nType in the client's last name");
        //    string ClientLName = Console.ReadLine();
        //    User objUser = Manager.FindClientByName(ClientFName, ClientLName);
        //    if (objUser != null)
        //    {
        //        Console.WriteLine("Client's accounts: ");
        //        PrintAccountsAndStatus(objUser);
        //    }
        //    else
        //    {
        //        Console.WriteLine("No user found with that name");
        //    }
        //}        
        
        //private void AdminDisabledMenu(int UserKey)
        //{
        //    switch (UserKey)
        //    {
        //        case 1:
        //            RegisterUserAccMenuUI();
        //            break;
        //        case 2:
        //            ModifyClientDataUI();
        //            break;
        //        case 3:
        //            ConsultByClientUI();
        //            break;
        //        case 4:
        //            Console.WriteLine("Release a blocked account");
        //            break;
        //        case 5:
        //            Console.WriteLine("\nType in your I.D");
        //            int clientId;
        //            int tries = 0;
        //            int.TryParse(Console.ReadLine(), out clientId);
        //            User objUser = Manager.FindClientById(clientId);
        //            if (objUser != null)
        //            {
        //                while (tries < 3)
        //                {
        //                    Console.WriteLine("Please type in your Password");
        //                    string InputPassword = Console.ReadLine();
        //                    if (objUser.Password == InputPassword)
        //                    {
        //                        Console.WriteLine("Transactions menu");
        //                        //display transactions menual
        //                        tries = 4;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("\nWrong password");
        //                        tries++;
        //                    }
        //                }
        //                if (tries == 3)
        //                {

        //                    Manager.BlockClientAccs(objUser);
        //                    Console.WriteLine("Your accounts has been blocked due to three failed attempts,");

        //                }
        //            }
        //            break;
        //        default:
        //            Console.WriteLine("Input error");
        //            break;
        //    }
        //}
    }
}
