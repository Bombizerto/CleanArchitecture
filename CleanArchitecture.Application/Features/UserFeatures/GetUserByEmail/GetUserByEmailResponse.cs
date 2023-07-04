using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.UserFeatures.GetUserByEmail
{
    public sealed record GetUserByEmailResponse 
    {
        public Guid id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
