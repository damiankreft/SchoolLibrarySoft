using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SchoolLibrary.Models;
using SchoolLibrary.ViewModel;


namespace SchoolLibrary.Views
{
    /// <summary>
    /// Interaction logic for BooksView.xaml
    /// </summary>
    public partial class BooksViewUser : UserControl
    {
        private List<BookModel> BooksGrid = null;
        private BooksViewModel BooksViewModel = new BooksViewModel();

        public BooksViewUser()
        {
            InitializeComponent();
            BooksViewModel.InitBinding(ref /*DataGrid*/ gridBooks, ref /*List<BookModel>*/ BooksGrid);
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            BooksViewModel.SearchTextBoxGotFocus(ref searchTextBox);
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            BooksViewModel.SearchTextBoxLostFocus(ref searchTextBox);
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            BooksViewModel.Search(ref searchTextBox, ref gridBooks, ref BooksGrid, ref SearchOptionsComboBox);
            AvailabilityComboBox.SelectedItem = ComboBoxAvailabilityAll;
        }

        private void AvailabilityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AvailabilityComboBox.SelectedItem == ComboBoxAvailabilityAll)
            {
                BooksViewModel.AvailabilityComboBoxAvailabilityAll(ref /*ComboBox*/ AvailabilityComboBox, ref /*DataGrid*/ gridBooks, ref /*List<BookModel>*/ BooksGrid);
            }
            else if (AvailabilityComboBox.SelectedItem == ComboBoxAvailabilityAvailable)
            {
                BooksViewModel.AvailabilityComboBoxAvailabilityAvailable(ref /*ComboBox*/ AvailabilityComboBox, ref /*DataGrid*/ gridBooks, ref /*List<BookModel>*/ BooksGrid);
            }
            else if (AvailabilityComboBox.SelectedItem == ComboBoxAvailabilityUnavailable)
            {
                BooksViewModel.AvailabilityComboBoxAvailabilityUnavailable(ref /*ComboBox*/ AvailabilityComboBox, ref /*DataGrid*/ gridBooks, ref /*List<BookModel>*/ BooksGrid);
            }
            else
                return;
        }
    }
}