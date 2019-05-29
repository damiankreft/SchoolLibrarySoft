using SchoolLibrary.Models;

namespace SchoolLibrary.ViewModel
{
    class LoginViewModel
    {
        public static UserModel Logon(string username, string password)
        {
            UserModel user = Database.Database.Instance.Table<UserModel>().Where(i => i.Password == password && i.Username == username).FirstOrDefaultAsync().Result;
            return user;
        }
    }
}