using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.UserFeatures.DeleteUserByEmail
{
    public sealed class DeleteUserByEmailValidator : AbstractValidator<DeleteUserByEmailRequest>
    {
        public DeleteUserByEmailValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        }
    }
}
