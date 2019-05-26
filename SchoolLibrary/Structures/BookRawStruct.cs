namespace SchoolLibrary.Structures
{
    public struct BookRawStruct
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ReleaseYear { get; set; }
        public string Publisher { get; set; }
        public bool IsAvailable { get; set; }

        public BookRawStruct(string id, string title, string author, string releaseYear, string publisher, bool availability)
        {
            Id = id;
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
            Publisher = publisher;
            IsAvailable = availability;
        }
    }
}
