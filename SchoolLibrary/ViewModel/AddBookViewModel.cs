using SchoolLibrary.Models;
using System.Text.RegularExpressions;

namespace SchoolLibrary.ViewModel
{
    static class AddBookViewModel
    {
        public static void Add(string author, bool availability, string publisher, string title, string releaseYear)
        {
            if (IsReleaseYearValid(releaseYear))
            {
                Database.Database.Instance.SaveItemAsync(new BookModel() { Author = author, IsAvailable = availability, Publisher = publisher, Title = title, ReleaseYear = System.Int32.Parse(releaseYear) });
            }
            else
            {
                System.Console.WriteLine("Invalid data");
            }
        }

        private static bool IsReleaseYearValid(string releaseYear)
        {
            return new Regex(@"^[0-9]+$").IsMatch(releaseYear) ? true : false;
        }
    }
}
