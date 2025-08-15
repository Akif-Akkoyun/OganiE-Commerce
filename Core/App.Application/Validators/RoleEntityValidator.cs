using App.Domain.Entities;
using FluentValidation;

namespace App.Application.Validators
{
    public class RoleEntityValidator : AbstractValidator<RoleEntity>
    {
        public RoleEntityValidator()
        {
            RuleFor(role => role.RoleName)
                .NotEmpty().WithMessage("Role name is required.")
                .MaximumLength(50).WithMessage("Role name must not exceed 50 characters.");
        }
    }
}
