﻿using System.Windows;
using System.Windows.Controls;
using SchoolLibrary.ViewModel;
using SchoolLibrary.Structures;

namespace SchoolLibrary.Views
{
    /// <summary>
    /// Interaction logic for EditBookView.xaml
    /// </summary>
    public partial class EditBookView : UserControl
    {
        public EditBookView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //  DateTime.Parse(releaseDate.Text).Date put this into new method
            BookRawStruct book = new BookRawStruct(id.Text, title.Text, author.Text, releaseYear.Text, publisher.Text, availability.IsChecked.Value);
            if(EditBookViewModel.IsValidInput(book))
            {
                EditBookViewModel.Edit(book);
            }
            
        }
    }
}
