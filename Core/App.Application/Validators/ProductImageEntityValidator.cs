using App.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Validators
{
    public class ProductImageEntityValidator : AbstractValidator<ProductImageEntity>
    {
        public ProductImageEntityValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID is required.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Image URL is required.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("Image URL must be a valid URL.");

            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("Created At date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Created At must be in the past.");

        }
    }
}
