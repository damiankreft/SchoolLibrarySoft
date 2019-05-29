using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolLibrary.Models;
using SQLite;
using System.IO;

namespace SchoolLibrary.Database
{
    public sealed class Database : SQLiteAsyncConnection
    {       
        private static Database database = null;
        //public Database(string databasePath) : base(databasePath, false) { }
        public readonly string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SchoolLibrary.db3";
        public Database(string dbPath) : base(dbPath, false) { }

        public static Database Instance
        {
            get
            {
                try
                {
                    if (database == null)
                    {
                        if (File.Exists(Properties.Settings.Default.DatabaseFileLocation))
                        {
                            database = new Database(Properties.Settings.Default.DatabaseFileLocation);
                            database.CreateTableAsync<BookModel>().Wait();
                            database.CreateTableAsync<UserModel>().Wait();
                        }
                        else
                        {
                            database = new Database(Properties.Settings.Default.DatabaseFileLocation);
                            database.CreateTableAsync<BookModel>();
                            database.CreateTableAsync<UserModel>().Wait();
                            SaveUserAsync(new UserModel() { Id = 0, AccessLevel = 3, Password = "admin", Username = "admin" });
                            SaveUserAsync(new UserModel() { Id = 1, AccessLevel = 0, Password = "user", Username = "user" });
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message + "\n");
                    Console.WriteLine(e.StackTrace);
                }
                return database;
            }
        }

        // Logon methods
        public static UserModel CheckCredentials(string username, string password)
        {
            return Instance.Table<UserModel>().Where(i => i.Username == username && i.Password == password).ToListAsync().Result.FirstOrDefault();
        }

        public static Task<int> SaveUserAsync(UserModel user)
        {
            return Instance.InsertAsync(user);
        }

        // Saves item to Instance
        public Task<int> SaveItemAsync(BookModel book)
        {
            return Instance.InsertAsync(book);
        }

        public Task<int> UpdateItemAsync(BookModel book)
        {
            return Instance.UpdateAsync(book);
        }

        // Mainly used by 'Search' button. Provides searching by: id, title(part), author(part),
        // release date,
        // publisher(part), availability.
        // 
        // IMPORTANT!
        // GetItemsByReleaseDate requires implementation in model class - date sent to DB is broken - and also down here
        public Task<List<BookModel>> GetItemsAsync()
        {
             return Instance.Table<BookModel>().ToListAsync();
        }

        public Task<BookModel> GetItemAsync(uint id)
        {
            return Instance.Table<BookModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<BookModel>> GetItemsByTitleAsync(string title)
        {
            return Instance.Table<BookModel>().Where(i => i.Title.Contains(title)).ToListAsync();
        }
 
        public Task<List<BookModel>> GetItemsByAuthorAsync(string author)
        {
            return Instance.Table<BookModel>().Where(i => i.Author.Contains(author)).ToListAsync();
        }

        public Task<List<BookModel>> GetItemsByReleaseDate(int releaseDate)
        {
            return Instance.Table<BookModel>().Where(i => i.ReleaseYear == releaseDate).ToListAsync();
        }

        public Task<List<BookModel>> GetItemsByPublisherAsync(string publisher)
        {
            return Instance.Table<BookModel>().Where(i => i.Publisher.Contains(publisher)).ToListAsync();
        }

        public Task<List<BookModel>> GetItemsAvailableAsync()
        {
            return Instance.Table<BookModel>().Where(i => i.IsAvailable).ToListAsync();
        }

        public Task<List<BookModel>> GetItemsNotAvailableAsync()
        {
            return Instance.Table<BookModel>().Where(i => i.IsAvailable == false).ToListAsync();
        }

        public Task RemoveItemAsync(uint id)
        {
            return Instance.Table<BookModel>().Where(i => i.Id == id).DeleteAsync();
        }
    }
}
