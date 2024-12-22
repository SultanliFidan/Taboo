namespace Taboo.Exceptions.Word
{
    public class InvalidBannedWordCountException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ErrorMessage { get; }

        public InvalidBannedWordCountException()
        {
            ErrorMessage = "Banned word count must be eqaul to 6";
        }

        public InvalidBannedWordCountException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }

}
