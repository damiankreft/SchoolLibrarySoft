using SQLite;

namespace SchoolLibrary.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public uint Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
    }
}
