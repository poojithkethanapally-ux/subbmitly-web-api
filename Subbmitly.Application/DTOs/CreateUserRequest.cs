using Subbmitly.Application.Const_and_Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subbmitly.Application.DTOs
{
    public class CreateUserRequest
    {
        public string fullName { get; set; }
        public string email { get; set; }
        //public string Password { get; set; }
        public UserRoleEnum role { get; set; }
    }
}
