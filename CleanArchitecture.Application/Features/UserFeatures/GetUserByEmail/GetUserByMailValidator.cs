using FluentValidation;


namespace CleanArchitecture.Application.Features.UserFeatures.GetUserByEmail
{
    public sealed class GetUserByMailValidator : AbstractValidator<GetUserByEmailRequest>
    {
        public GetUserByMailValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        }
    }    
}
