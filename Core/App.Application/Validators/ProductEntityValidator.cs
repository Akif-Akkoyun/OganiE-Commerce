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
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(product => product.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(product => product.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than zero.");
            RuleFor(product => product.SellerId)
                .GreaterThan(0).WithMessage("SellerId must be greater than zero.");
            RuleFor(product => product.StockAmount)
                .InclusiveBetween((byte)0, (byte)255).WithMessage("StockAmount must be between 0 and 255.");
            RuleFor(product => product.Enabled)
                .NotNull().WithMessage("Enabled cannot be null.")
                .Must(enabled => enabled == true || enabled == false)
                .WithMessage("Enabled must be a boolean value (true or false).");
        }
    }
}
