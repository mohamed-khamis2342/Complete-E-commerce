using E_commerce.Auth;
using E_commerce.Core.Commends.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Auth
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommend, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangePasswordHandler(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }




        public async Task<string> Handle(ChangePasswordCommend request, CancellationToken cancellationToken)
        {
            var UserFromDb = await _userManager.FindByIdAsync(request.CustomerId);
            if (UserFromDb is null)
                return "User is not Existed";
            var CheckPass = await _userManager.CheckPasswordAsync(UserFromDb, request.CurrentPassword);
            if (!CheckPass)
                return "Current Password is not correct";

            if (request.NewPassword != request.ConfirmNewPassword)
                return "New Password and Confirm New Password should be the same";
            var result = await _userManager.ChangePasswordAsync(
                UserFromDb,
                request.NewPassword,
                request.ConfirmNewPassword

                );
            if (!result.Succeeded)
                return "Something went wrong ";



            return string.Empty;

        }
    }
}
