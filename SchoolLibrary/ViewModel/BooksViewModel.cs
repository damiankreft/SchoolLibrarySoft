using System;
using System.Collections.Generic;
using System.Linq;
using SchoolLibrary.Models;
using System.Windows.Controls;

namespace SchoolLibrary.ViewModel
{
    public class BooksViewModel
    {
        // Should I use "ref" in front of reference types too or just skip it?
        public void InitBinding(ref DataGrid booksView, ref List<BookModel> BooksGrid)
        {
            BooksGrid = Database.Database.Instance.GetItemsAsync().Result;
            booksView.ItemsSource = BooksGrid;
        }

        public void SearchTextBoxGotFocus(ref TextBox searchTextBox)
        {
            string defaultText = Properties.Resources.BooksView_searchBoxDefaultText;
            searchTextBox.Text = (searchTextBox.Text == defaultText) ? searchTextBox.Text = "" : searchTextBox.Text = searchTextBox.Text;
        }

        public void SearchTextBoxLostFocus(ref TextBox searchTextBox)
        {
            string defaultText = Properties.Resources.BooksView_searchBoxDefaultText;
            searchTextBox.Text = IsInputValid(ref searchTextBox) ? searchTextBox.Text = searchTextBox.Text : searchTextBox.Text = defaultText;
        }

        private bool IsInputValid(ref TextBox inputTextBox)
        {
            if (String.IsNullOrEmpty(inputTextBox.Text) || String.IsNullOrWhiteSpace(inputTextBox.Text)) return false;
            else return true;
        }

        private bool IsInputValid(string inputText)
        {
            if (String.IsNullOrEmpty(inputText) || String.IsNullOrWhiteSpace(inputText)) return false;
            else return true;
        }

        public void Search(ref TextBox searchTextBox, ref DataGrid gridBooks, ref List<BookModel> BooksGrid, ref ComboBox comboBox)
        {
            switch(comboBox.SelectedIndex)
            {
                case 0:
                    SearchById(ref searchTextBox, ref gridBooks, ref BooksGrid);
                    break;
                case 1:
                    SearchByTitle(ref searchTextBox, ref gridBooks, ref BooksGrid);
                    break;
                case 2:
                    SearchByAuthor(ref searchTextBox, ref gridBooks, ref BooksGrid);
                    break;
                case 3:
                    SearchByPublisher(ref searchTextBox, ref gridBooks, ref BooksGrid);
                    break;
                case 4:
                    SearchByReleaseDate(ref searchTextBox, ref gridBooks, ref BooksGrid);
                    break;
                default:
                    SearchNoFilters(ref gridBooks, ref BooksGrid);
                    break;
            }
        }

        public void ClearSearch(TextBox searchTextBox, ComboBox searchOptions)
        {
            searchOptions.ToolTip = "Select search mode specyfiing how data will be filtered.";
            // Escapes the scale of switch-case instruction to call default case.
            searchOptions.SelectedIndex = -1;
            searchTextBox.Text = Properties.Resources.BooksView_searchBoxDefaultText;
            // test twefewfwsdfadfsadfdwas
        }

        public void Return(string id)
        {
            BookModel book = null;
            if (UInt32.TryParse(id, out uint _id))
            {
                book = Database.Database.Instance.GetItemAsync(_id).Result;
                if (book.IsAvailable == false)
                {
                    book.IsAvailable = true;
                    Database.Database.Instance.UpdateAsync(book);
                }
            }
        }

        public void Borrow(string id)
        {
            BookModel book = null;
            if (UInt32.TryParse(id, out uint _id))
            {
                book = Database.Database.Instance.GetItemAsync(_id).Result;
                if (book.IsAvailable == true)
                {
                    book.IsAvailable = false;
                    Database.Database.Instance.UpdateAsync(book);
                }
            }
        }

        private void SearchById(ref TextBox searchTextBox, ref DataGrid gridBooks, ref List<BookModel> BooksGrid)
        {
            string text = searchTextBox.Text;
            if (IsInputValid(text) && text != Properties.Resources.BooksView_searchBoxDefaultText)
            {
                if (UInt32.TryParse(text, out uint _id))
                {
                    BooksGrid = Database.Database.Instance.Table<BookModel>().ToListAsync().Result;
                    BooksGrid = BooksGrid.Where(i => i.Id == _id).ToList();
                    gridBooks.ItemsSource = BooksGrid;
                }
            }
        }
        private void SearchByTitle(ref TextBox searchTextBox, ref DataGrid gridBooks, ref List<BookModel> BooksGrid)
        {
            string text = searchTextBox.Text;
            if (IsInputValid(text) && text != Properties.Resources.BooksView_searchBoxDefaultText)
            {
                BooksGrid = Database.Database.Instance.Table<BookModel>().ToListAsync().Result;
                BooksGrid = BooksGrid.Where(i => i.Title.Contains(text)).ToList();
                gridBooks.ItemsSource = BooksGrid;
            }
        }
        private void SearchByAuthor(ref TextBox searchTextBox, ref DataGrid gridBooks, ref List<BookModel> BooksGrid)
        {
            string text = searchTextBox.Text;
            if (IsInputValid(text) && text != Properties.Resources.BooksView_searchBoxDefaultText)
            {
                BooksGrid = Database.Database.Instance.Table<BookModel>().ToListAsync().Result;
                BooksGrid = BooksGrid.Where(i => i.Author.Contains(text)).ToList();
                gridBooks.ItemsSource = BooksGrid;
            }
        }
        private void SearchByReleaseDate(ref TextBox searchTextBox, ref DataGrid gridBooks, ref List<BookModel> BooksGrid)
        {
            if (IsInputValid(searchTextBox.Text) && searchTextBox.Text != Properties.Resources.BooksView_searchBoxDefaultText)
            {
                if (Int32.TryParse(searchTextBox.Text, out int _releaseYear))
                {
                    BooksGrid = Database.Database.Instance.Table<BookModel>().Where(i => i.ReleaseYear == _releaseYear).ToListAsync().Result;
                    gridBooks.ItemsSource = BooksGrid;
                }
            }
        }
        private void SearchByPublisher(ref TextBox searchTextBox, ref DataGrid gridBooks, ref List<BookModel> BooksGrid)
        {
            string text = searchTextBox.Text;
            if (IsInputValid(text) && text != Properties.Resources.BooksView_searchBoxDefaultText)
            {
                BooksGrid = Database.Database.Instance.Table<BookModel>().ToListAsync().Result;
                BooksGrid = BooksGrid.Where(i => i.Publisher.Contains(text)).ToList();
                gridBooks.ItemsSource = BooksGrid;
            }
        }
        private void SearchNoFilters(ref DataGrid gridBooks, ref List<BookModel> BooksGrid)
        {
            BooksGrid = Database.Database.Instance.Table<BookModel>().ToListAsync().Result;
            gridBooks.ItemsSource = BooksGrid;
        }

        public void AvailabilityComboBoxAvailabilityAll(ref ComboBox AvailabilityComboBox, ref DataGrid gridBooks, ref List<BookModel> BooksGrid)
        {
            gridBooks.ItemsSource = null;
            BooksGrid = Database.Database.Instance.GetItemsAsync().Result;
            gridBooks.ItemsSource = BooksGrid;
            gridBooks.Items.Refresh();
        }

        public void AvailabilityComboBoxAvailabilityAvailable(ref ComboBox AvailabilityComboBox, ref DataGrid gridBooks, ref List<BookModel> BooksGrid)
        {
            gridBooks.ItemsSource = null;
            BooksGrid = Database.Database.Instance.Table<BookModel>().Where(i => i.IsAvailable).ToListAsync().Result;
            gridBooks.ItemsSource = BooksGrid;
            gridBooks.Items.Refresh();
        }

        public void AvailabilityComboBoxAvailabilityUnavailable(ref ComboBox AvailabilityComboBox, ref DataGrid gridBooks, ref List<BookModel> BooksGrid)
        {
            gridBooks.ItemsSource = null;
            BooksGrid = Database.Database.Instance.Table<BookModel>().Where(i => i.IsAvailable == false).ToListAsync().Result;
            gridBooks.ItemsSource = BooksGrid;
            gridBooks.Items.Refresh();
        }
    }
}