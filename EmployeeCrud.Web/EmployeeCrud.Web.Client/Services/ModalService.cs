using Microsoft.AspNetCore.Components;

namespace EmployeeCrud.Web.Client.Services;

public class ModalService : IModalService
{
    public event Action<string, RenderFragment> OnShow = default!;
    public event Action OnClose = default!;

    public void Show(string title, Type contentType)
    {

        var content = new RenderFragment(x => { x.OpenComponent(1, contentType); x.CloseComponent(); });
        OnShow?.Invoke(title, content);
    }

    public void Close()
    {
        OnClose?.Invoke();
    }
}
