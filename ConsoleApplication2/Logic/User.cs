using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Logic
{
    class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public bool UserType { get; set; }
        public List<Account> Accounts { get; set; }
        public int tries = 0;
        public bool AdminON = true;

        public User(string pName, string pLastName, int pUserId, int pPhone, bool pUserType)
        {
            this.Name = pName;
            this.LastName = pLastName;
            this.UserId = pUserId;
            this.Phone = pPhone;
            this.UserType = pUserType;
            this.Accounts = new List<Account>();
            this.Password = PasswordGenerator(pName, pLastName, pUserId);
        }

        private string PasswordGenerator(string pName, string pLastName, int pUserId)
        {
            string pw = pName.Substring(0, 1);
            pw += pLastName.Substring(0, 1);
            pw += pUserId.ToString().Substring(0, 3);
            return pw;
        }

        public void ChangePassword(string newPassword)
        {
            this.Password = newPassword;
        }

        public string UserToString()
        {
            string UserInfo = "the user's id is: " + UserId + "\n" +
                              "the user's name is: " + Name + "\n" +
                              "the user's last name is: " + LastName + "\n" +
                              "the user's phone is: " + Phone + "\n";
            foreach (Account acc in Accounts)
            {
                acc.AccToString();

                UserInfo += acc.AccToString();
            }
            return UserInfo;
        }
    }
}
