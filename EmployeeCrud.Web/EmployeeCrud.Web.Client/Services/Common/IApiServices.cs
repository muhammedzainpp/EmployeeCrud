using EmployeeCrud.Web.Shared.Responses;

namespace EmployeeCrud.Web.Client.Services.Common;

public interface IApiServices
{
    Task<Response<Empty>> Delete(string url, int id);
    Task<Response<T>> Get<T>(string url);
    Task<Response<T>> GetById<T>(string url, int id);
    Task<Response<int>> Post<T>(string url, T request);
}
