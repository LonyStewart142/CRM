namespace CRM.Application.Models
{
    public class Result<T>
    {
        public bool Ok { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }
    }
}
