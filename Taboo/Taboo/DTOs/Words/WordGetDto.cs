namespace Taboo.DTOs.Words
{
    public class WordGetDto
    {
        public string Text { get; set; }
        public string Language { get; set; }
        public HashSet<string> BannedWords { get; set; }
    }
}
