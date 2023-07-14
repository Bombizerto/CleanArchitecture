using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Features.UserFeatures.GetUserByEmail;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Application.Features.UserFeatures.DeleteUserByEmail
{
    public sealed class DeleteUserByEmailMapper: Profile
    {
        public DeleteUserByEmailMapper() 
        {
            CreateMap<DeleteUserByEmailRequest, User>();
            CreateMap<User, DeleteUserByEmailResponse>();
            CreateMap<DeleteUserByEmailResponse, User>();
        }
    }
}
