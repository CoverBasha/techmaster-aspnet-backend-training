namespace TrainingCenter.Api.Services
{
    public class ServiceResponse<T>
    {
        public Status Status { get; set; } = Status.Success;
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
    }

    public enum Status
    {
        Success,
        Error,
        NotFound
    }
}
