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
using SchoolLibrary.Database;
using SchoolLibrary.Models;
using SchoolLibrary.ViewModel;

namespace SchoolLibrary.Views
{
    /// <summary>
    /// Interaction logic for AddBookView.xaml
    /// </summary>
    public partial class AddBookView : UserControl
    {
        public AddBookView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //  DateTime.Parse(releaseDate.Text).Date put this into new method
            AddBookViewModel.Add(author.Text, availability.IsChecked.Value, publisher.Text, title.Text, Int32.Parse(releaseYear.Text));
            
        }
    }
}
