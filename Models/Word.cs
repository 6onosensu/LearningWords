using SQLite;

namespace LearningWords.Models
{
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string WordText { get; set; }
        public string Translation { get; set; }
        public string Explanation { get; set; }
        public string Category { get; set; }
        public int RepetitionCount {  get; set; }
    }
}
