using SQLite;

namespace SchoolLibrary.Models
{
    public class BookModel
    {
        [PrimaryKey, AutoIncrement]
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public string Publisher { get; set; }
        public bool IsAvailable { get; set; }
    }
}
