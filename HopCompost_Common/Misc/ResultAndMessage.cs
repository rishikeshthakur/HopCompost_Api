namespace HopCompost_Common.Misc
{
    public class ResultAndMessage
    {
        public static ResultAndMessage Successful => new ResultAndMessage(true, null);

        public static ResultAndMessage Failed(string message)
        {
            return new ResultAndMessage(false, message);
        }

        public static ResultAndMessage Succeeded(string message)
        {
            return new ResultAndMessage(true, message);
        }

        public ResultAndMessage(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }

        public bool IsSuccessful { get; private set; }
        public string Message { get; private set; }
    }
}