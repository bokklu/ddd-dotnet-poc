using FluentValidation;
using POC.DDD.Application.DTOs.Input;

namespace POC.DDD.Application.Validators
{
    public class BusinessRequestValidator : AbstractValidator<BusinessRequest>
    {
        public BusinessRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
