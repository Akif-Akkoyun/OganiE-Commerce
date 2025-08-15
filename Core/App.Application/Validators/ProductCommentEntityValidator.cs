using App.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Validators
{
    public class ProductCommentEntityValidator : AbstractValidator<ProductCommentEntity>
    {
        public ProductCommentEntityValidator() 
        {
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Comment text cannot be empty.")
                .MaximumLength(500).WithMessage("Comment text cannot exceed 500 characters.");
            RuleFor(x => x.StarCount)
                .InclusiveBetween((byte)1, (byte)5).WithMessage("Star count must be between 1 and 5.");
            RuleFor(x => x.CreatedAt)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Created date cannot be in the future.");
            RuleFor(x => x.IsConfirmed)
                .NotNull().WithMessage("Confirmation status must be specified.");
        }
    }
}
