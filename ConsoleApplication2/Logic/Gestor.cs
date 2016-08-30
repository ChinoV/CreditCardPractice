using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Logic
{
    class Gestor
    {
        private List<User> Users { get; set; }
        private int LastAccId { get; set; }
        public bool AdminPaswordOnOff { get; private set; }
        public static User Admin = new User("admin", "admin", 123, 0, true);
        public static User UserInSesion;
        public static Account AccInSesion;

        #region Methods

        public Gestor()
        {
            Admin.Password = "admin";
            this.Users = new List<User>();
        }

        public string PasswordGenerator(string Name, string LastName, int UserId)
        {
            string pw = Name.Substring(0, 1);
            pw += LastName.Substring(0, 1);
            pw += UserId.ToString().Substring(0, 3);
            return pw;
        }

        public void RegisterUserAndAcc(string Name, string LastName, int UserId, int Phone, bool UserType, double credit)
        {

            User Client = new User(Name, LastName, UserId, Phone, UserType);
            Client.Password = PasswordGenerator(Name, LastName, UserId);
            RegisterAcc(credit, Client);
            this.Users.Add(Client);

        }

        public void RegisterAcc(double credit, User Client)
        {
            Account Acc = new Account("Acc-" + ++LastAccId, credit);
            Client.Accounts.Add(Acc);
        }

        public void AdminPwOnOff(bool OnOff)
        {
            if (OnOff == true)
            {
                AdminPaswordOnOff = true;
            }
            else
            {
                AdminPaswordOnOff = false;
            }
        }
        public User FindClientById(int clientId)
        {
            foreach (User User in Users)
            {
                if (clientId == User.UserId)
                {
                    return User;
                }
            }
            return null;
        }

        public Account FindAccById(string accId)
        {
            
            foreach (Account Acc in UserInSesion.Accounts)
            {
                if (Acc.accId.Equals(accId))
                {
                    return Acc;
                }
            }
            return null;
        }

        public User FindClientByName(string fName, string lName)
        {
            foreach (User User in Users)
            {
                if (fName == User.Name && lName == User.LastName)
                {
                    return User;
                }
            }
            return null;
        }

        public void ModifyClient(User objUser, string newName, string newLastName, int newUserId, int newPhone, string newPassword)
        {
            // modify user data
            objUser.Name = newName;
            objUser.LastName = newLastName;
            objUser.UserId = newUserId;
            objUser.Phone = newPhone;
            objUser.Password = newPassword;
        }

        
        public void BlockClientAccs(User Client)
        {
            foreach (Account Acc in Client.Accounts)
            {
                if (Acc.Blocked == false)
                {
                    Acc.Blocked = true;
                }
            }
        }

        public void UnblockClientAccs(int cId)
        {
            User Client = FindClientById(cId);
            foreach (Account Acc in Client.Accounts)
            {
                if (Acc.Blocked == true)
                {
                    Acc.Blocked = false;
                }
            }
        }
         
        public void UnblockAcc(Account Acc)
        {
            if (Acc.Blocked == true)
            {
                Acc.Blocked = false;
            }
        }

        #endregion

        public void RegisterMethodDemo(string pName, string pLastName, int pUserId, int pPhone, double pCredit)
        {
            User objUser = new User(pName, pLastName, pUserId, pPhone, false);
            int countAccounts = objUser.Accounts.Count;
            Users.Add(objUser);
            objUser.Accounts.Add(new Account("cta-" + ++countAccounts, pCredit));
        }

        public void RegisterMethodDemo(string pName, string pLastName, int pUserId, int pPhone)
        {
            User objUser = new User(pName, pLastName, pUserId, pPhone, false);
            int countAccounts = objUser.Accounts.Count;
            Users.Add(objUser);
            objUser.Accounts.Add(new Account("cta-" + ++countAccounts));
        }
        
        public void ModifyMethodDemo(int pId, string pName, string pLastName, int pUserId, int pPhone)
        {
            User objUser = FindClientById(pId);
            objUser.Name = pName;
            objUser.LastName = pLastName;
            objUser.UserId = pUserId;
            objUser.Phone = pPhone;
        }

        public void AddAccountDemo(int pId, double pCredit)
        { 
            int countAccounts = UserInSesion.Accounts.Count;
            UserInSesion.Accounts.Add(new Account("cta-" + ++countAccounts, pCredit));
        }

        public void AddAccountDemo()
        { 
            int countAccounts = UserInSesion.Accounts.Count;
            UserInSesion.Accounts.Add(new Account("cta-" + ++countAccounts));
        }

        public bool ClientExists(int pId)
        {
            foreach(User user in Users)
            {
                if (user.UserId == pId)
                {
                    return true;
                }
            }

            return false;
        }

        public string GetUserInfo(int pId)
        {
            User x = FindClientById(pId);
            if (x!=null)
            {
                return x.UserToString();
            }
            else
            {
                return "";
            }
        }

        public string GetAccInfo(string pId)
        {
            Account x = FindAccById(pId);
            if (x != null)
            {
                return x.AccToString();
            }
            else
            {
                return "";
            }
        }

        public string GetAccInSesionInfo()
        {
            if (AccInSesion != null)
            {
                return AccInSesion.AccToString();
            }
            else
            {
                return "";
            }
        }

        public string GetAccInSesionBalance()
        {
            return AccInSesion.AccBalanceString();
            
        }

        public bool ValidateAdminPassword(string pInputPassword)
        {
            if(Admin.Password==pInputPassword)
            {
                return true;
            }
            return false;
        }

        public bool ValidateClientPassword(string pClientPassword)
        { 
            if (UserInSesion.Password == pClientPassword)
            {
                UserInSesion.tries=0;
                return true;
            }
            else
            {
                UserInSesion.tries++;
                if (UserInSesion.tries == 3)
                {
                    BlockClientAccs(UserInSesion);
                    Console.WriteLine("Your Accounts have been blocked");
                }
            }
            return false;
        }
        
        public bool ValidateAccStatus()
        { 
            foreach (Account Acc in UserInSesion.Accounts)
            {

                if (Acc.Blocked == true)
                {
                    return false;
                }
            }
            return true; 
        } 

        public void SetUserInSesion (int pId)
        {
            UserInSesion = FindClientById(pId); 
        }

        public void SetAccInSesion(string pId)
        {
            AccInSesion = FindAccById(pId);
        }

        public void DisableAdmin()
        {
            Admin.AdminON = false;
        }

        public bool ValidateAdminStatus()
        {
            if (Admin.AdminON == true)
            {
                return true;
            }
            return false;
        }

        public double WithdrawMoney( double pAmount)
        {
            if (AccInSesion.Withdraw(pAmount))
            {
                return pAmount;
            }
            return 0;
        }

        public void BuyArticle(double pAmount)
        {
            AccInSesion.Buy(pAmount); 
        }

        public double PaymentCc(double pAmount)
        {
            if (AccInSesion.PayCc(pAmount))
            {
                return pAmount;
            }
            return 0;
        }

        public string TxtTransactions()
        {
            string txtTransactions="";
            foreach (Transaction Trnsctn in AccInSesion.Transactions)
            {
                
                txtTransactions+= Trnsctn.TransactionToString();
                
            }
            return txtTransactions;
        } 

        public bool PasswordChange(string pPw1, string pPw2)
        {
            if (pPw1 == pPw2)
            {
                UserInSesion.ChangePassword(pPw2);
                return true;
            }
            return false;
        }
  
    }
}
