namespace Application.Client.Dtos
{
    public class HttpResponseDto<T>
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public T Object { get; set; }
    }
}
