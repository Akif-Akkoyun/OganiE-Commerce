using App.Domain.Entities;
using FluentValidation;

namespace App.Application.Validators
{
    public class CategoryEntityValidator : AbstractValidator<CategoryEntity>
    {
        public CategoryEntityValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Category description must not exceed 500 characters.");
        }
    }
}
