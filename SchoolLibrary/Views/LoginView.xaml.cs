using System;
using System.Windows;
using System.Windows.Controls;
using SchoolLibrary.Models;
using SchoolLibrary.ViewModel;

namespace SchoolLibrary.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void ProcessLogonButton_Click(object sender, RoutedEventArgs e)
        {

            UserModel user = null;
            if (!String.IsNullOrEmpty(usernameTextBox.Text) || !String.IsNullOrEmpty(passwordTextBox.Text))
            {
                user = LoginViewModel.Logon(usernameTextBox.Text, passwordTextBox.Text);

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
                            wnd.DataContext = new BooksViewUser();
                            break;
                    }
                    
                }
            }
        }
    }
}
