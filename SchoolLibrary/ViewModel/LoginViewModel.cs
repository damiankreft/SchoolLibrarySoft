using SchoolLibrary.Models;
using SchoolLibrary.Views;
using System;
using System.Windows;

namespace SchoolLibrary.ViewModel
{
    class LoginViewModel
    {
        public static void Logon(string username, string password)
        {
            if (ValidateInput(username, password))
            {
                UserModel user = Database.Database.Instance.Table<UserModel>().Where(i => i.Password == password && i.Username == username).FirstOrDefaultAsync().Result;
                SetView(user);
            }
        }

        private static bool ValidateInput(string username, string password)
        {
            if (!String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(password))
                return true;
            else
                return false;
        }

        private static void SetView(UserModel user)
        {
            if (user != null)
            {
                MainWindow wnd = (MainWindow)Application.Current.MainWindow;
                switch (user.AccessLevel)
                {
                    case 0:
                        wnd.DataContext = new BooksViewUser();
                        break;
                    case 1:
                        wnd.DataContext = new BooksViewUser();
                        break;
                    case 2:
                        wnd.DataContext = new BooksViewUser();
                        break;
                    case 3:
                        wnd.DataContext = new BooksView();
                        break;
                    default:
                        break;
                }

            }
        }
    }
}