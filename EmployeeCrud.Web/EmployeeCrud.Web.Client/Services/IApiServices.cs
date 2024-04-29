using EmployeeCrud.Web.Shared.Responses;

namespace EmployeeCrud.Web.Client.Services;

public interface IApiServices
{
    Task<Response<T>> Get<T>(string url);
    Task<Response<T>> GetById<T>(string url, int id);
    Task<Response<int>> Post<T>(string url, T request);
}
