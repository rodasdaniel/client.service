namespace Application.Client.Common.Handler
{
    public class HttpResponseException
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
    }
}
