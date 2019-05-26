using System.Windows;
using System.Windows.Controls;
using SchoolLibrary.ViewModel;

namespace SchoolLibrary.Views
{
    public partial class RemoveBookView : UserControl
    {
        public RemoveBookView()
        {
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveBookViewModel.Remove(bookId);
        }
    }
}
