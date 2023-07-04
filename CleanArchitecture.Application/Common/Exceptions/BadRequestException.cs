using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string[]errors) : base("Multiple errors ocurred. See error details.") 
        {
            Errors = errors;
        }
        public string[] Errors { get; set; }
    }
}
