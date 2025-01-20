using System.Net;

namespace money_management_service.Core
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        public object Error { get; set; }

        public Pagination? Pagination { get; set; }

        public APIResponse(T data, Pagination pagination = null, string message = "Success", HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = true;
            Data = data;
            Message = message;
            StatusCode = statusCode;
            Error = null;
            Pagination = pagination;
        }

        public APIResponse(HttpStatusCode statusCode, string message, object error = null) 
        {
            Success = false;
            StatusCode = statusCode;
            Message = message;
            Data = default(T);
            Error = error;
        }
    }
}
