using FluentValidation;

namespace EmployeeCrud.Web.Application.Employees.Commands;
public class SaveEmployeeCommandValidator : AbstractValidator<SaveEmployeeCommand>
{
    public SaveEmployeeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}

