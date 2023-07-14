using CleanArchitecture.Application.Features.UserFeatures.CreateUser;
using CleanArchitecture.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.UserFeatures.GetUserByEmail
{
    public sealed class GetUserByEmailMapper: Profile
    {
        public GetUserByEmailMapper() 
        {
            CreateMap<GetUserByEmailRequest, User>();
            CreateMap<User, GetUserByEmailResponse>();
            CreateMap<GetUserByEmailResponse, User>();
        }
    }
}
