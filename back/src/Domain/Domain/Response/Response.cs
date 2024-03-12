namespace TwoFactorAuthenticator.Models.Response
{
    public class Response<T>
    {
        public Response(int statusCode, string message)
        {
            StatusCode = statusCode;
            Data = new ResponseData<T>(message);
        }
        public Response(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Data = new ResponseData<T>(message, data);
        }


        public int StatusCode { get; set; }
        public ResponseData<T> Data { get; set; }


    }

    public class ResponseData<T>
    {
        public ResponseData(string message)
        {
            Message = message;
        }

        public ResponseData(string message, T data)
        {
            Message = message;
            Data = data;
        }

        public string Message { get; set; }
        public T Data { get; set; }
    }
}
