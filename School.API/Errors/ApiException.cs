namespace School.API.Errors
{
    public class ApiException
    {
        public ApiException(string statusCode, string message, string details)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }
        public string StatusCode { get; }
        public string Message { get; }
        public string Details { get; }
    }
}