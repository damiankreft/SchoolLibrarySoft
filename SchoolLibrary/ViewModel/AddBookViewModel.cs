using SchoolLibrary.Models;

namespace SchoolLibrary.ViewModel
{
    static class AddBookViewModel
    {
        public static void Add(string author, bool availability, string publisher, string title, int releaseYear)
        {
            Database.Database.Instance.SaveItemAsync(new BookModel() { Author = author, IsAvailable = availability, Publisher = publisher, Title = title, ReleaseYear = releaseYear});
        }
    }
}
