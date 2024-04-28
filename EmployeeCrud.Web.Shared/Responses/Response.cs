namespace EmployeeCrud.Web.Shared.Responses;
public class Response<T>
{
    public bool IsSuccess { get; set; }
    public T? Result { get; set; }
    public IEnumerable<string>? Errors { get; set; }

}
