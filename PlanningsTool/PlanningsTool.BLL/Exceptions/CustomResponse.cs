namespace PlanningsTool.BLL.Exceptions
{
    public class CustomResponse
    {
        public CustomResponse(int statusCode, string message, string details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string Message { get; private set; }
        public string Details { get; private set; }
    }
}
