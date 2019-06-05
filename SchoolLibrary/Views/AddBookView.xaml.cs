using System;
using System.Windows;
using System.Windows.Controls;
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
            AddBookViewModel.Add(author.Text, availability.IsChecked.Value, publisher.Text, title.Text, releaseYear.Text);
            
        }
    }
}
