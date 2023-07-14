using AutoMapper;
using CleanArchitecture.Application.Features.UserFeatures.CreateUser;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserNUnitTest.Helper
{
    public class MappingTest : Profile
    {
        public MappingTest() 
        {
            CreateMap<User, CreateUserRequest>();
            CreateMap<User, CreateUserResponse>();
            CreateMap<CreateUserResponse, User>();
        }
    }
}
