using SchoolLibrary.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace SchoolLibrary.Views
{
    public partial class ReturnBook : UserControl
    {
        private BooksViewModel BooksViewModel = new BooksViewModel();

        public ReturnBook()
        {
            InitializeComponent();
        }

        private void ReturnButton_Clicked(object sender, RoutedEventArgs e)
        {
            BooksViewModel.Return(bookId.Text);
        }
    }
}
