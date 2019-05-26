using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolLibrary.Models;
using System.Windows.Controls;
using SchoolLibrary.Views;

namespace SchoolLibrary.ViewModel
{
    class LoginViewModel
    {
        public static UserModel Logon(string username, string password)
        {
            UserModel user = Database.Database.Instance.Table<UserModel>().Where(i => i.Password == password && i.Username == username).FirstOrDefaultAsync().Result;
            return user;
        }
    }
}