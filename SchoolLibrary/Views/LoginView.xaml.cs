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
            LoginViewModel.Logon(usernameTextBox.Text, passwordBox.Password);
        }
    }
}
