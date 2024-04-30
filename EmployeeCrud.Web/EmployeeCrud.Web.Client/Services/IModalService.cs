
namespace EmployeeCrud.Web.Client.Services;

public interface IModalService
{
    void Close();
    void Show(string title, Type contentType);
    
}
