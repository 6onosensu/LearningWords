using LearningWords.Models;
using SQLite;

namespace LearningWords.Classes
{
    public class DbHelper
    {
        private SQLiteAsyncConnection _database;
        public DbHelper()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "LearningWords.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Word>().Wait();
        }

        public Task<int> SaveWord(Word word)
        {
            if (word.Id != 0)
            {
                return _database.UpdateAsync(word);
            }
            else
            {
                return _database.InsertAsync(word);
            }
        }

        public Task<int> DeleteWord(Word word)
        {
            return _database.DeleteAsync(word);
        }
    }
}
