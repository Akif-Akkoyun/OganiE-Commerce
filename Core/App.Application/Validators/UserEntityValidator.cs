using App.Domain.Entities;
using FluentValidation;

namespace App.Application.Validators
{
    public class UserEntityValidator : AbstractValidator<UserEntity>
    {
        public UserEntityValidator()
        {
            RuleFor(user => user.CreatedAt)
                .NotEmpty().WithMessage("CreatedAt cannot be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("CreatedAt must be in the past or present.");
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name cannot be empty.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");
            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last name cannot be empty.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.");
            RuleFor(user => user.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than 0.")
                .WithMessage("RoleId must be a valid role.");
            RuleFor(user => user.Enabled)
                .NotNull().WithMessage("Enabled cannot be null.")
                .Must(enabled => enabled == true || enabled == false).WithMessage("Enabled must be a boolean value.");
        }
    }
}