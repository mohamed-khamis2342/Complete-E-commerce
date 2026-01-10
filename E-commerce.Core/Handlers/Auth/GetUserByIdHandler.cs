using E_commerce.Auth;
using E_commerce.Core.DTOs.AuthDTOs;
using E_commerce.Core.Queries.User;
using E_commerce.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Auth
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ApiResponse<UpdateResponseDTO>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserByIdHandler(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task<ApiResponse<UpdateResponseDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var UserFromDb = await _userManager.FindByIdAsync(request.UserId);
            if (UserFromDb == null)
                return new ApiResponse<UpdateResponseDTO>(400, "User is not found");


            var UserSend = new UpdateResponseDTO
            {
                CustomerId = UserFromDb.Id,
                FirstName = UserFromDb.FirstName,
                LastName = UserFromDb.LastName,
                Email = UserFromDb.Email,
                PhoneNumber = UserFromDb.PhoneNumber,
                DateOfBirth = UserFromDb.DateOfBirth,

            };
            return new ApiResponse<UpdateResponseDTO>()
            {
                StatusCode = 200,
                Success = true,
                Data = UserSend

            };
        }
    }
}
