using App.Domain.Entities;
using FluentValidation;

namespace App.Application.Validators
{
    public class ProductEntityValidator : AbstractValidator<ProductEntity>
    {
        public ProductEntityValidator()
        {
            RuleFor(product => product.CreatedAt)
                .NotEmpty().WithMessage("CreatedAt cannot be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("CreatedAt must be in the past or present.");
            RuleFor(product => product.UpdatedAt)
                .NotEmpty().WithMessage("UpdatedAt cannot be empty.")
                .GreaterThanOrEqualTo(product => product.CreatedAt).WithMessage("UpdatedAt must be greater than or equal to CreatedAt.");
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(product => product.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
