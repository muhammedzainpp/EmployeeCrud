using EmployeeCrud.Web.Shared.Responses;

namespace EmployeeCrud.Web.Application.Helpers;
public class ResponseHelpers
{
    public static Response<T> OnSuccess<T>(T result)
     => new Response<T> { IsSuccess = true, Result = result };

    public static Response<T> OnError<T>(Exception ex)
     => new Response<T> { IsSuccess = false, Errors = new[] { ex.Message } };
}

