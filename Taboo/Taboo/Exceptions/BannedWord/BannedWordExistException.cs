namespace Taboo.Exceptions.BannedWord
{
    public class BannedWordExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public BannedWordExistException()
        {
            ErrorMessage = "BannedWord already added in database";
        }

        public BannedWordExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
