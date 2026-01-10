using E_commerce.Auth;
using E_commerce.Core.Commends.Auth;
using E_commerce.Core.DTOs.AuthDTOs;
using E_commerce.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Auth
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommend, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateUserHandler(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task<string> Handle(UpdateUserCommend request, CancellationToken cancellationToken)
        {
            var UserFromDB = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (UserFromDB == null)
                return "Id is not valid";
            if (request == null)
                return "Data is not valid";


            UserFromDB.FirstName = request.FirstName;
            UserFromDB.LastName = request.LastName;
            UserFromDB.UserName = $"{request.FirstName}_{request.LastName}";
            UserFromDB.Email = request.Email;
            UserFromDB.PhoneNumber = request.PhoneNumber;
            UserFromDB.DateOfBirth = request.DateOfBirth;


            await _userManager.UpdateAsync(UserFromDB);



            return string.Empty;
        }
    }
}
