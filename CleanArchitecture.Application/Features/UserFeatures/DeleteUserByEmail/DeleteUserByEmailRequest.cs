using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace CleanArchitecture.Application.Features.UserFeatures.DeleteUserByEmail
{
    public sealed record DeleteUserByEmailRequest(string Email, string Name): IRequest<DeleteUserByEmailResponse>
    {

    }
}
