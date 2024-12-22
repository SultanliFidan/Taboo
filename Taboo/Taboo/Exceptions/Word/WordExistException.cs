namespace Taboo.Exceptions.Word
{
    public class WordExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public WordExistException()
        {
            ErrorMessage = "Word already added in database";
        }

        public WordExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
