using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchoolLibrary.Models;
using SchoolLibrary.Database;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Data;
using SchoolLibrary.Views;
using SchoolLibrary.ViewModel;


namespace SchoolLibrary.Views
{
    /// <summary>
    /// Interaction logic for BooksView.xaml
    /// </summary>
    public partial class BooksView : UserControl
    {
        private List<BookModel> BooksGrid = null;
        private BooksViewModel BooksViewModel = new BooksViewModel();

        public BooksView()
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