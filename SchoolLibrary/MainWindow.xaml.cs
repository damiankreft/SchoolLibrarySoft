using System.Windows;
using SchoolLibrary.ViewModel;

namespace SchoolLibrary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
