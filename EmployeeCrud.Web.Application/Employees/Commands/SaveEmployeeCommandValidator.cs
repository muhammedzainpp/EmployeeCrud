using FluentValidation;

namespace EmployeeCrud.Web.Application.Employees.Commands;
public class SaveEmployeeCommandValidator : AbstractValidator<SaveEmployeeCommand>
{
    public SaveEmployeeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name Should Not Be Empty");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description Should Not Be Empty");
    }
}

