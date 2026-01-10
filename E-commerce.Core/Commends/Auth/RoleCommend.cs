using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Commends.Auth
{
    public class RoleCommend:IRequest<string>
    {
        public Guid UserID { get; set; }
        public string RoleName { get; set; }
    }
}
