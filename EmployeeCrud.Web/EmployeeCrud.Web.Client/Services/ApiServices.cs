using EmployeeCrud.Web.Shared.Responses;
using System.Net.Http.Json;

namespace EmployeeCrud.Web.Client.Services;

public class ApiServices(HttpClient http) : IApiServices
{
    private readonly HttpClient http = http;

    public async Task<Response<T>> Get<T>(string url)
    {
        var response = await http.GetFromJsonAsync<Response<T>>(url) ?? default!;
        return response;
    }

    public async Task<Response<T>> GetById<T>(string url, int id)
    {
        var response = await http.GetFromJsonAsync<Response<T>>($"{url}/{id}") ?? default!;
        return response;
    }

    public async Task<Response<int>> Post<T>(string url, T request)
    {
        var response = await http.PostAsJsonAsync(url, request) ?? default!;
        return await response.Content.ReadFromJsonAsync<Response<int>>() ?? default!;
    }

}
