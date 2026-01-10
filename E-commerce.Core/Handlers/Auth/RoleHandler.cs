using E_commerce.Auth;
using E_commerce.Core.Commends.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Auth
{
    public class RoleHandler : IRequestHandler<RoleCommend, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RoleHandler(UserManager<ApplicationUser> userManager,RoleManager<Role> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public async Task<string> Handle(RoleCommend request, CancellationToken cancellationToken)
        {
            var UserFromDB = await _userManager.FindByIdAsync(request.UserID);
            if (UserFromDB == null)
                return "User dosent exist";
            var RoleExist = await _roleManager.FindByNameAsync(request.RoleName);
            if (RoleExist is null)
                return "Role dosent exist";

            var UserRoleExist = await _userManager.IsInRoleAsync(UserFromDB, "Customer");
            if (UserRoleExist)
                return "User has this Role";
            var result
                    = await _userManager.AddToRoleAsync(UserFromDB, "Customer");
            return result.Succeeded ? string.Empty : "somthing went wrong";
        }
    }
}
