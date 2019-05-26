using System;
using SchoolLibrary.Models;
using SchoolLibrary.Structures;

namespace SchoolLibrary.ViewModel
{
    class EditBookViewModel
    {
        public static void Edit(BookRawStruct book)
        {
            UInt32.TryParse(book.Id, out uint _id);
            Database.Database.Instance.UpdateItemAsync(new BookModel() { Id = _id, Author = book.Author, IsAvailable = book.IsAvailable, Publisher = book.Publisher, Title = book.Title, ReleaseYear = int.Parse(book.ReleaseYear) });
        }

        private static bool IsNullOrWhitespaceOrEmpty(string t)
        {
            return String.IsNullOrWhiteSpace(t) || String.IsNullOrEmpty(t) ? true : false;
        }

        public static bool IsDateValid(BookRawStruct book)
        {
            return Int32.TryParse(book.ReleaseYear, out int _releaseYear) ? true : false;
        }

        public static bool IsValidInput(BookRawStruct book)
        {
            return UInt32.TryParse(book.Id, out uint _id) && !IsNullOrWhitespaceOrEmpty(book.Author) && !IsNullOrWhitespaceOrEmpty(book.Publisher) && !IsNullOrWhitespaceOrEmpty(book.Title) && !IsNullOrWhitespaceOrEmpty(book.ReleaseYear) && Int32.TryParse(book.ReleaseYear, out int _releaseYear)
? true
: false;
        }
    }
}
