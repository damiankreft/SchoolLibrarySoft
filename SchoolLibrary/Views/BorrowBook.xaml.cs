using System.Windows;
using System.Windows.Controls;
using SchoolLibrary.ViewModel;

namespace SchoolLibrary.Views
{
    /// <summary>
    /// Interaction logic for BorrowBook.xaml
    /// </summary>
    public partial class BorrowBook : UserControl
    {
        private BooksViewModel BooksViewModel = new BooksViewModel();

        public BorrowBook()
        {
            InitializeComponent();
        }

        private void BorrowButton_Clicked(object sender, RoutedEventArgs e)
        {
            BooksViewModel.Borrow(bookId.Text);
        }
    }
}
