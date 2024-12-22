namespace Taboo.DTOs.Words
{
    public class WordUpdateDto
    {
        public string Text { get; set; }
        public HashSet<string> BannedWords { get; set; }
    }
}
