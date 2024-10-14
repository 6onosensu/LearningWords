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

        public async Task<List<Word>> GetAllWords() => await _database.Table<Word>().ToListAsync();

        public async Task<Word> GetWordById(int id) => await _database
            .Table<Word>().FirstOrDefaultAsync(W => W.Id == id);

        public void GetWordsByCategory(string category)
        {

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
