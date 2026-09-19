namespace task_03_products_categories_api.Services
{
    public class ServiceResponse<T>
    {
        public Status Status { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
    }

    public enum Status
    {
        Success, Failure, NotFound
    }
}
