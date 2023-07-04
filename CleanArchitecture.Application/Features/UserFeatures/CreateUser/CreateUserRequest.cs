﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace CleanArchitecture.Application.Features.UserFeatures.CreateUser
{
    public sealed record CreateUserRequest(string Email, string Name): IRequest<CreateUserResponse>
    {

    }
}
