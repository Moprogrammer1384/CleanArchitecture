using Catalog.API.Application.Dtos.Products;
using FluentValidation;

namespace Catalog.API.Application.Validators.Products;

public class ProductForAddValidator : AbstractValidator<ProductForAddDto>
{
    public ProductForAddValidator()
    {
        // Validation Rules

        RuleFor(p => p.Name).NotEmpty()
                            .MinimumLength(3)
                            .MaximumLength(30);
                            
    }
}
